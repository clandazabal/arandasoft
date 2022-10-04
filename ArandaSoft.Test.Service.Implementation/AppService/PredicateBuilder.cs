namespace ArandaSoft.Test.Service.Implementation.AppService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    /// Clase que genera los predicados de una consulta con multiples filtros.
    /// </summary>
    public static class PredicateBuilder
    {
        #region Methods

        /// <summary>
        /// Expression that generates queries with TRUE condition.
        /// </summary>
        /// <typeparam name="T">Genéric object</typeparam>
        /// <returns>Build predicate</returns>
        public static Expression<Func<T, bool>> True<T>()
        {
            return param => true;
        }

        /// <summary>
        /// Expresión para la generación de Queries con condición 'OR'.
        /// </summary>
        /// <typeparam name="T">Objeto generico</typeparam>
        /// <param name="expr1">Expression 1</param>
        /// <param name="expr2">Expression 2</param>
        /// <returns>Build predicate</returns>
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return expr1.Compose(expr2, Expression.OrElse);
        }

        /// <summary>
        /// Expresión para la generación de Queries con condición 'AND'.
        /// </summary>
        /// <typeparam name="T">Objeto generico</typeparam>
        /// <param name="expr1">Expression 1</param>
        /// <param name="expr2">Expression 2</param>
        /// <returns>Build predicate</returns>
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1, Expression<Func<T, bool>> expr2)
        {
            return expr1.Compose(expr2, Expression.AndAlso);
        }

        /// <summary>    
        /// Combina la primera expresión con la segunda usando la función de combinación específica.
        /// </summary>    
        static Expression<T> Compose<T>(this Expression<T> expr1, Expression<T> expr2, Func<Expression, Expression, Expression> merge)
        {
            var map = expr1.Parameters.Select((f, i) => new { f, s = expr2.Parameters[i] }).ToDictionary(p => p.s, p => p.f);  
            var secondBody = ParameterRebinder.ReplaceParameters(map, expr2.Body);
 
            return Expression.Lambda<T>(merge(expr1.Body, secondBody), expr1.Parameters);
        }

        #endregion

        #region Clase
        class ParameterRebinder : ExpressionVisitor
        {
            readonly Dictionary<ParameterExpression, ParameterExpression> map;

            ParameterRebinder(Dictionary<ParameterExpression, ParameterExpression> map)
            {
                this.map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
            }

            public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> map, Expression exp)
            {
                return new ParameterRebinder(map).Visit(exp);
            }

            protected override Expression VisitParameter(ParameterExpression p)
            {
                ParameterExpression replacement;

                if (map.TryGetValue(p, out replacement))
                {
                    p = replacement;
                }

                return base.VisitParameter(p);
            }
        }

        #endregion
    }
}
