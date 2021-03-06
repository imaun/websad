﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Websad.Core.App
{
    public class AppWebConfig
    {
        public string UploadPhotoPath { get; set; }
        /// <summary>
        /// Valid photo file extensions seperated by semi-colon(;).
        /// </summary>
        public string ValidPhotoFileExtensions { get; set; }
        public string[] ValidPhotoFileExtensionsList =>
            ValidPhotoFileExtensions?.Split(';');
    }
}
