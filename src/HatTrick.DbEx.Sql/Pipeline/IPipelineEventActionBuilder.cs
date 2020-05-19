using System;

namespace HatTrick.DbEx.Sql.Pipeline
{
    public interface IPipelineEventActionBuilder<TPredicate>
    {
        void When(Predicate<TPredicate> predicate);
    }
}
