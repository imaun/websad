using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Websad.Core.App;
using Websad.Resources;
using Websad.Core.Extensions;
using Websad.Core.Exceptions;

namespace Websad.Api.Utils
{
    public class FileUploadHelper
    {
        
        private readonly IOptionsSnapshot<WebsadConfig> _setting;
        private readonly IHostingEnvironment _hostEnv;

        public FileUploadHelper(
            IHostingEnvironment hostEnv,
            IOptionsSnapshot<WebsadConfig> setting
        ) {
            hostEnv.CheckArgumentIsNull(nameof(hostEnv));
            _hostEnv = hostEnv;
            setting.CheckArgumentIsNull();
            _setting = setting;
        }

        #region Properties

        private WebsadConfig Options => _setting.Value;

        public string PhotoRootPath => Options.WebConfig
            .UploadPhotoPath.Replace("~", _hostEnv.WebRootPath);

        public string[] ValidPhotoExtensions =>
            Options.WebConfig.ValidPhotoFileExtensionsList;

        #endregion

        #region Methods

        private void CreateDirIfNotExist(string path) {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        private string GetUniqueFileName(Guid fileId, string fileName) {
            fileName = Path.GetFileName(fileName);

            return Path.GetFileNameWithoutExtension(fileName)
                   + "_"
                   + fileId.ToString().Substring(0, 4)
                   + Path.GetExtension(fileName);
        }

        private string GetUploadUrl(string path, string filename) {
            if (!path.EndsWith("/"))
                path += "/";

            return $"{path}{filename}";
        }

        private void CheckPhotoExtension(string filename) {
            var ext = Path.GetExtension(filename);
            if (!ValidPhotoExtensions.Contains(ext))
                throw new UploadFileExtensionNotValidException();
        }

        public async Task<FileUploadResult> UploadPhotoAsync(IFormFile fileInfo) {
            fileInfo.CheckArgumentIsNull();
            var result = new FileUploadResult {
                StartDateTime = DateTime.Now
            };
            CheckPhotoExtension(fileInfo.FileName);
            CreateDirIfNotExist(PhotoRootPath);
            var filename = GetUniqueFileName(result.Id, fileInfo.FileName);
            result.UploadUrl = GetUploadUrl(Options.WebConfig.UploadPhotoPath, filename);
            result.TargetFileName = Path.Combine(PhotoRootPath, filename);
            try {
                await fileInfo.CopyToAsync(
                    new FileStream(result.TargetFileName,
                        FileMode.Create)
                );
            }
            catch (UploadFileExtensionNotValidException e) {
                result.Exception = e;
                result.HasError = true;
                result.ErrorMessage = AppText.UploadFileExtNotValid;
            }
            catch (Exception e) {
                result.Exception = e;
                result.HasError = true;
                result.ErrorMessage = AppText.FileUploadError;
            }
            finally {
                result.FinishDateTime = DateTime.Now;
            }

            return await Task.FromResult(result);
        }



        #endregion
    }

    public class FileUploadResult
    {
        public FileUploadResult() {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? FinishDateTime { get; set; }
        public string TargetFileName { get; set; }
        public string UploadUrl { get; set; }
        public string ErrorMessage { get; set; }
        public Exception Exception { get; set; }
        public bool HasError { get; set; }
        public override string ToString()
            => UploadUrl;
    }
}
