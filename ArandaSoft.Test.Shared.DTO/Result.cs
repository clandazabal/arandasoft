namespace ArandaSoft.Test.Shared.DTO
{
    public class Result
    {
        #region Constructor

        /// <summary>
        /// Constructor de la clase. Inicializa succes=false por default.
        /// </summary>
        public Result()
        {
            success = false;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Mensaje a mostrar.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Transacción exitosa ?
        /// </summary>
        private bool success;

        /// <summary>
        /// Inicializa el resultado de la transaccion.
        /// </summary>
        public bool Success
        {
            get
            {
                return success;
            }

            set
            {
                success = value;
            }
        }

        #endregion
    }
}
