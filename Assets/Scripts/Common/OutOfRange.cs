using System;

namespace Common
{
    /// <summary>
    /// 지정된 값 또는 허용 범위를 넘어갔을 때 발생하는 예외 클래스입니다.
    /// </summary>
    [Serializable]
    public class OutOfRange : Exception
    {
        public string ParamName { get; }
        public object ActualValue { get; }
        public object MinValue { get; }
        public object MaxValue { get; }

        public OutOfRange()
            : base("지정된 값을 넘어갔거나 범위를 벗어났습니다.")
        {
        }

        public OutOfRange(string message)
            : base(message)
        {
        }

        public OutOfRange(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public OutOfRange(string paramName, string message)
            : base(FormatMessage(paramName, message, null))
        {
            ParamName = paramName;
        }

        public OutOfRange(string paramName, object actualValue, string message)
            : base(FormatMessage(paramName, message, actualValue))
        {
            ParamName = paramName;
            ActualValue = actualValue;
        }

        public OutOfRange(string paramName, object actualValue, object min, object max)
            : base(FormatMessage(paramName, $"값이 허용 범위({min} ~ {max})를 벗어났습니다.", actualValue))
        {
            ParamName = paramName;
            ActualValue = actualValue;
            MinValue = min;
            MaxValue = max;
        }

        public OutOfRange(object actualValue, object min, object max)
            : this(null, actualValue, min, max)
        {
        }

        private static string FormatMessage(string paramName, string message, object actualValue)
        {
            string header = string.IsNullOrEmpty(paramName) ? message : $"[{paramName}] {message}";

            if (actualValue != null)
            {
                return $"{header} (전달된 값: {actualValue})";
            }

            return header;
        }
    }
}
