#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
#pragma warning disable
using Best.HTTP.SecureProtocol.Org.BouncyCastle.Crypto.Utilities;

namespace Best.HTTP.SecureProtocol.Org.BouncyCastle.Bcpg.Sig
{
    /**
    * packet giving time after creation at which the key expires.
    */
    public class KeyExpirationTime
        : SignatureSubpacket
    {
        protected static byte[] TimeToBytes(long t)
        {
            return Pack.UInt32_To_BE((uint)t);
        }

        public KeyExpirationTime(
            bool    critical,
            bool    isLongLength,
            byte[]  data)
            : base(SignatureSubpacketTag.KeyExpireTime, critical, isLongLength, data)
        {
        }

        public KeyExpirationTime(
            bool    critical,
            long    seconds)
            : base(SignatureSubpacketTag.KeyExpireTime, critical, false, TimeToBytes(seconds))
        {
        }

        /**
        * Return the number of seconds after creation time a key is valid for.
        *
        * @return second count for key validity.
        */
        public long Time => (long)Pack.BE_To_UInt32(data);
    }
}
#pragma warning restore
#endif
