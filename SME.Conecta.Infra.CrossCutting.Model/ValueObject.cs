using SME.Conecta.Infra.CrossCutting.Model.ModelRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace SME.Conecta.Infra.CrossCutting.Model
{
    [Serializable]
    public abstract class ValueObject<TModel> : IEquatable<TModel>, IModel where TModel : ValueObject<TModel>
    {
        private List<PropertyInfo> RegisteredProperties { get; } = new List<PropertyInfo>();

        public override bool Equals(object obj)
        {
            if (obj is null) return false;

            return Equals(obj as TModel);
        }

        public virtual bool Equals(TModel other)
        {
            if (other is null) return false;

            if (ReferenceEquals(this, other)) return true;

            if (GetType() != other.GetType())
                return false;

            foreach (var property in GetProperties())
            {
                if (null == property.GetValue(this, null)) return null == property.GetValue(other, null);
                if (false == property.GetValue(this, null).Equals(property.GetValue(other, null))) return false;
            }

            return true;
        }

        protected void RegisterProperty(Expression<Func<TModel, object>> expression)
        {
            if (expression == null)
                throw new ArgumentNullException("A expressão para registrar a propriedade não pode ser nula.");

            MemberExpression memberExpression;

            if (ExpressionType.Convert == expression.Body.NodeType)
            {
                var body = (UnaryExpression)expression.Body;
                memberExpression = body.Operand as MemberExpression;
            }
            else
            {
                memberExpression = expression.Body as MemberExpression;
            }

            if (memberExpression == null)
                throw new InvalidOperationException("Não foi possível registrar a propriedade com a expressão passada.");

            RegisteredProperties.Add(memberExpression.Member as PropertyInfo);
        }

        public override int GetHashCode()
        {
            var hashCode = 31;
            var changeMultiplier = false;

            foreach (var property in GetProperties())
            {
                var value = property.GetValue(this, null);

                if (value != null)
                {
                    hashCode = hashCode * ((changeMultiplier) ? 59 : 114) + value.GetHashCode();
                    changeMultiplier = !changeMultiplier;
                }
                else
                    hashCode = hashCode ^ (1 * 13);
            }

            return hashCode;
        }

        public static bool operator ==(ValueObject<TModel> left, ValueObject<TModel> right) => Equals(left, null) ? (Equals(right, null)) : left.Equals(right);

        public static bool operator !=(ValueObject<TModel> left, ValueObject<TModel> right) => !(left == right);

        private IEnumerable<PropertyInfo> GetProperties()
        {
            if (RegisteredProperties.Any())
                return RegisteredProperties;

            return GetType().GetProperties();
        }
    }
}
