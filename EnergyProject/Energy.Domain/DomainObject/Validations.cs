using System.Text.RegularExpressions;

namespace Energy.Domain.DomainObject
{
    public class Validations
    {
        public static void ValidIsNullOrWhiteSpace(string value, string message)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException(message);
        }

        public static void ValidIsEquals(object object1, object object2, string message)
        {
            if (object1.Equals(object2))
                throw new DomainException(message);
        }

        public static void ValidIsDifferent(object object1, object object2, string message)
        {
            if (!object1.Equals(object2))
                throw new DomainException(message);
        }

        public static void ValidIsDifferent(string pattern, string value, string message)
        {
            var regex = new Regex(pattern);

            if (!regex.IsMatch(value))
                throw new DomainException(message);
        }

        public static void ValidSize(string value, int maximum, string message)
        {
            var length = value.Trim().Length;
            if (length > maximum)
                throw new DomainException(message);
        }

        public static void ValidSizeRange(string value, int minimo, int maximum, string message)
        {
            var length = value.Trim().Length;
            if (length < minimo || length > maximum)
                throw new DomainException(message);
        }

        public static void ValidIsEmpty(string value, string message)
        {
            if (value == null || value.Trim().Length == 0)
                throw new DomainException(message);
        }

        public static void ValidIsNull(object object1, string message)
        {
            if (object1 == null)
                throw new DomainException(message);
        }

        public static void ValidMinimoMaximum(double value, double minimo, double maximum, string message)
        {
            if (value < minimo || value > maximum)
                throw new DomainException(message);
        }

        public static void ValidMinimoMaximum(float value, float minimo, float maximum, string message)
        {
            if (value < minimo || value > maximum)
                throw new DomainException(message);
        }

        public static void ValidMinimoMaximum(int value, int minimo, int maximum, string message)
        {
            if (value < minimo || value > maximum)
                throw new DomainException(message);
        }

        public static void ValidMinimoMaximum(long value, long minimo, long maximum, string message)
        {
            if (value < minimo || value > maximum)
                throw new DomainException(message);
        }

        public static void ValidMinimoMaximum(decimal value, decimal minimo, decimal maximum, string message)
        {
            if (value < minimo || value > maximum)
                throw new DomainException(message);
        }

        public static void ValidIsLessThan(long value, long minimo, string message)
        {
            if (value < minimo)
                throw new DomainException(message);
        }

        public static void ValidIsLessThan(double value, double minimo, string message)
        {
            if (value < minimo)
                throw new DomainException(message);
        }

        public static void ValidIsLessThan(decimal value, decimal minimo, string message)
        {
            if (value < minimo)
                throw new DomainException(message);
        }

        public static void ValidIsLessThan(int value, int minimo, string message)
        {
            if (value < minimo)
                throw new DomainException(message);
        }

        public static void ValidIsBiggerThen(long value, long minimo, string message)
        {
            if (value > minimo)
                throw new DomainException(message);
        }

        public static void ValidIsBiggerThen(double value, double minimo, string message)
        {
            if (value > minimo)
                throw new DomainException(message);
        }

        public static void ValidIsBiggerThen(decimal value, decimal minimo, string message)
        {
            if (value > minimo)
                throw new DomainException(message);
        }

        public static void ValidIsBiggerThen(int value, int minimo, string message)
        {
            if (value > minimo)
                throw new DomainException(message);
        }

        public static void ValidIsFalse(bool boolvalue, string message)
        {
            if (!boolvalue)
                throw new DomainException(message);
        }

        public static void ValidIsTrue(bool boolvalue, string message)
        {
            if (boolvalue)
                throw new DomainException(message);
        }

        public static void ValidIsOlderAge(DateTime value, string message)
        {
            if (value > DateTime.Now.AddYears(-18))
                throw new DomainException(message);
        }
    }
}
