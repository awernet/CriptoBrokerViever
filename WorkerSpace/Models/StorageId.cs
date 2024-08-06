using System;
using WorkerSpace.Interfaces;

namespace WorkerSpace.Models
{
    internal class StorageId : IStorageId
    {
        private Guid guid;

        public int GenerateId()
        {
            guid = Guid.NewGuid();
            return guid.GetHashCode();
        }

        public int GetId()
        {
            return guid.GetHashCode();
        }
    }
}
