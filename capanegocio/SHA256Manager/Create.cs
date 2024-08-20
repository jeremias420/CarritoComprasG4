using System.Security.Cryptography;

namespace SHA256Manager
{
    internal class Create : SHA256
    {
        public override void Initialize()
        {
            throw new System.NotImplementedException();
        }

        protected override void HashCore(byte[] array, int ibStart, int cbSize)
        {
            throw new System.NotImplementedException();
        }

        protected override byte[] HashFinal()
        {
            throw new System.NotImplementedException();
        }
    }
}