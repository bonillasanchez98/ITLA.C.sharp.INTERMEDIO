namespace BiblioCleanSol.Domain.Base
{
    public class OperationResult
    {
        public bool IsSuccess { get; set; }
        public string Messagge { get; set; } = string.Empty;
        public dynamic? Data { get; set; }


        public OperationResult()
        {
        }

        public OperationResult(bool isSuccess, string messagge, dynamic? data = null)
        {
            IsSuccess = isSuccess;
            Messagge = messagge;
            Data = data;
        }

        //Metodo Success
        public static OperationResult Success(string message, dynamic? data = null)
        {
            return new OperationResult(true, message, data);
        }

        //Metodo Failure
        public static OperationResult Failure(string message)
        {
            return new OperationResult(false, message);
        }
    }
}
