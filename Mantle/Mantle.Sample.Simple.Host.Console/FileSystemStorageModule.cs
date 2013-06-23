﻿using Mantle.Storage;
using Mantle.Storage.FileSystem;
using Ninject.Modules;

namespace Mantle.Samples.Simple.Host.Console
{
    public class FileSystemStorageModule : NinjectModule
    {
        public override void Load()
        {
            // TODO: Setup file system storage clients here.

            Bind<IStorageClient>()
                .To<FileSystemStorageClient>()
                .InTransientScope()
                .OnActivation(c => c.Setup("SimpleStorage", "Enter the storage directory path here."));
        }
    }
}