﻿namespace WebAppKovaApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ErrorValidationModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int ErrorCode { get; } = StatusCodes.Status406NotAcceptable;

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<KeyValuePair<string, string>> Errors { get; set; }
    }
}
