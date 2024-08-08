using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LMS_UnitTest.Helper
{
    public static class MockQueryableExtensions
    {
        public static Mock<IQueryable<T>> CreateMockQueryable<T>(IQueryable<T> sourceList)
        {
            var mockQueryable = new Mock<IQueryable<T>>();

            mockQueryable.As<IAsyncEnumerable<T>>()
                         .Setup(m => m.GetAsyncEnumerator(It.IsAny<CancellationToken>()))
                         .Returns(new TestAsyncEnumerator<T>(sourceList.GetEnumerator()));

            mockQueryable.As<IQueryable<T>>()
                         .Setup(m => m.Provider)
                         .Returns(new TestAsyncQueryProvider<T>(sourceList.Provider));

            //mockQueryable.As<IQueryable<T>>()
            //    .Setup(m => m.FirstOrDefaultAsync(It.IsAny<CancellationToken>()))
            //    .Returns(new TestAsyncEnumerator<T>(sourceList.First()))

            mockQueryable.As<IQueryable<T>>().Setup(m => m.Expression).Returns(sourceList.Expression);
            mockQueryable.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(sourceList.ElementType);
            mockQueryable.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(sourceList.GetEnumerator());

            return mockQueryable;
        }
    }

    public class TestAsyncQueryProvider<TEntity> : IAsyncQueryProvider
    {
        private readonly IQueryProvider _inner;

        public TestAsyncQueryProvider(IQueryProvider inner)
        {
            _inner = inner;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            return new TestAsyncEnumerable<TEntity>(expression);
        }

        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new TestAsyncEnumerable<TElement>(expression);
        }

        public object Execute(Expression expression)
        {
            return _inner.Execute(expression);
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return _inner.Execute<TResult>(expression);
        }

        public IAsyncEnumerable<TResult> ExecuteAsync<TResult>(Expression expression)
        {
            return new TestAsyncEnumerable<TResult>(expression);
        }

        public TResult ExecuteAsync<TResult>(Expression expression, CancellationToken cancellationToken)
        {
            return Execute<TResult>(expression);
        }
    }

    public class TestAsyncEnumerable<T> : EnumerableQuery<T>, IAsyncEnumerable<T>, IQueryable<T>
    {
        public TestAsyncEnumerable(IEnumerable<T> enumerable) : base(enumerable)
        {
        }

        public TestAsyncEnumerable(Expression expression) : base(expression)
        {
        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new TestAsyncEnumerator<T>(this.AsEnumerable().GetEnumerator());
        }

        IQueryProvider IQueryable.Provider => new TestAsyncQueryProvider<T>(this);
    }

    //public class TestFirstOrDefaultAsync<T> : 

    public class TestAsyncEnumerator<T> : IAsyncEnumerator<T>
    {
        private readonly IEnumerator<T> _inner;

        public TestAsyncEnumerator(IEnumerator<T> inner)
        {
            _inner = inner;
        }

        public ValueTask DisposeAsync()
        {
            _inner.Dispose();
            return ValueTask.CompletedTask;
        }

        public ValueTask<bool> MoveNextAsync()
        {
            return new ValueTask<bool>(_inner.MoveNext());
        }

        public T Current => _inner.Current;
    }
}
