﻿using Cabinet.Core.Results;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Cabinet.Core.Providers {
    /// <summary>
    /// Provides IO operations for a storage provider i.e. FileSystem, S3, AzureBlobStorage
    /// Ideally it should be implemented in a thread safe maner so it can be used as a singleton
    /// </summary>
    /// <typeparam name="T">Provider Configuration</typeparam>
    public interface IStorageProvider<T> where T : IStorageProviderConfig {
        string ProviderType { get; }
        
        Task<bool> ExistsAsync(string key, T config);
        Task<IEnumerable<string>> ListKeysAsync(T config, string keyPrefix = "", bool recursive = true);

        Task<ICabinetItemInfo> GetFileAsync(string key, T config);
        Task<IEnumerable<ICabinetItemInfo>> GetItemsAsync(T config, string keyPrefix = "", bool recursive = true);

        Task<Stream> OpenReadStreamAsync(string key, T config);

        Task<ISaveResult> SaveFileAsync(string key, Stream content, HandleExistingMethod handleExisting, IProgress<WriteProgress> progress, T config);
        Task<ISaveResult> SaveFileAsync(string key, string filePath, HandleExistingMethod handleExisting, IProgress<WriteProgress> progress, T config);

        Task<IMoveResult> MoveFileAsync(string sourceKey, string destKey, HandleExistingMethod handleExisting, T config);
        Task<IDeleteResult> DeleteFileAsync(string key, T config);
    }
}
