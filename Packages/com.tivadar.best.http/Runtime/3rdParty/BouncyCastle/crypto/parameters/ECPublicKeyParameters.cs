#if !BESTHTTP_DISABLE_ALTERNATE_SSL && (!UNITY_WEBGL || UNITY_EDITOR)
#pragma warning disable
using System;
using System.Globalization;

using Best.HTTP.SecureProtocol.Org.BouncyCastle.Asn1;
using Best.HTTP.SecureProtocol.Org.BouncyCastle.Math.EC;

namespace Best.HTTP.SecureProtocol.Org.BouncyCastle.Crypto.Parameters
{
    public class ECPublicKeyParameters
        : ECKeyParameters
    {
        private readonly ECPoint q;

        public ECPublicKeyParameters(
            ECPoint				q,
            ECDomainParameters	parameters)
            : this("EC", q, parameters)
        {
        }

        public ECPublicKeyParameters(
            string				algorithm,
            ECPoint				q,
            ECDomainParameters	parameters)
            : base(algorithm, false, parameters)
        {
            this.q = ECDomainParameters.ValidatePublicPoint(Parameters.Curve, q);
        }

        public ECPublicKeyParameters(
            string				algorithm,
            ECPoint				q,
            DerObjectIdentifier publicKeyParamSet)
            : base(algorithm, false, publicKeyParamSet)
        {
            this.q = ECDomainParameters.ValidatePublicPoint(Parameters.Curve, q);
        }

        public ECPoint Q
        {
            get { return q; }
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;

            ECPublicKeyParameters other = obj as ECPublicKeyParameters;

            if (other == null)
                return false;

            return Equals(other);
        }

        protected bool Equals(
            ECPublicKeyParameters other)
        {
            return q.Equals(other.q) && base.Equals(other);
        }

        public override int GetHashCode()
        {
            return q.GetHashCode() ^ base.GetHashCode();
        }
    }
}
#pragma warning restore
#endif
