namespace ArandaSoft.Test.Shared.Parameter
{
    public class Parameter
    {
        #region Properties

        /// <summary>
        /// Ordenar por...
        /// </summary>
        public string OrderBy { get; set; }

        /// <summary>
        /// Ordenar por...
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// Número de página
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// Número de registros por página
        /// </summary>
        public int? PageSize { get; set; }

        #endregion
    }
}
