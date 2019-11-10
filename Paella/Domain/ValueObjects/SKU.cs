using System;

namespace Paella.Domain.ValueObjects
{
    public class SKU : IEquatable<SKU>
    {
        private readonly string _sku;

        public SKU(string sku)
        {
            // TODO: Validations
            _sku = sku;
        }

        public override string ToString() => _sku;

        public bool Equals(SKU other) => _sku == other._sku;

        public override bool Equals(object obj) => obj is SKU other && Equals(other);

        public override int GetHashCode() => _sku != null
            ? _sku.GetHashCode()
            : 0;
    }
}