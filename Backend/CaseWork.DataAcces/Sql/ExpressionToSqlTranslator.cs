using System.Linq.Expressions;

namespace CaseWork.DataAcces.Sql
{
    public static class ExpressionToSqlTranslator
    {
        public static string Translate<T>(Expression<Func<T, bool>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException(nameof(expression));

            var body = expression.Body as BinaryExpression;

            if (body == null)
                throw new ArgumentException("Invalid expression. Expected binary expression.");

            return TranslateBinaryExpression(body);
        }

        private static string TranslateBinaryExpression(BinaryExpression expression)
        {
            string left = TranslateExpression(expression.Left);
            string right = TranslateExpression(expression.Right);
            string operand = GetSqlOperator(expression.NodeType);

            return $"{left} {operand} {right}";
        }

        private static string TranslateExpression(Expression expression)
        {
            if (expression is MemberExpression memberExpression)
            {
                return memberExpression.Member.Name;
            }
            else if (expression is ConstantExpression constantExpression)
            {
                return constantExpression.Value.ToString();
            }
            else
            {
                throw new NotSupportedException($"Unsupported expression type: {expression.NodeType}");
            }
        }

        private static string GetSqlOperator(ExpressionType expressionType)
        {
            switch (expressionType)
            {
                case ExpressionType.Equal:
                    return "=";
                case ExpressionType.NotEqual:
                    return "<>";
                case ExpressionType.LessThan:
                    return "<";
                case ExpressionType.LessThanOrEqual:
                    return "<=";
                case ExpressionType.GreaterThan:
                    return ">";
                case ExpressionType.GreaterThanOrEqual:
                    return ">=";
                default:
                    throw new NotSupportedException($"Unsupported binary expression type: {expressionType}");
            }
        }
    }
}