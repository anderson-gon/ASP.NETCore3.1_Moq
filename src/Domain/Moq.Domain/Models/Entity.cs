using FluentValidation;
using FluentValidation.Results;

namespace Moq.Domain.Models
{
    public abstract class Entity<T>
    {
        public T Id { get; protected set; }
        public ValidationResult ValidationResult { get; private set; }
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{ GetType().Name} with Id: {Id}";
        }

        public bool Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator)
        {
            ValidationResult = validator.Validate(entity);
            return ValidationResult.IsValid;
        }
    }
}
