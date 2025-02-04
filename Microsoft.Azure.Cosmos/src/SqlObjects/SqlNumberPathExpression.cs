﻿//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------
namespace Microsoft.Azure.Cosmos.SqlObjects
{
    using Microsoft.Azure.Cosmos.SqlObjects.Visitors;

#if INTERNAL
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements should be documented
    public
#else
    internal
#endif
    sealed class SqlNumberPathExpression : SqlPathExpression
    {
        private SqlNumberPathExpression(SqlPathExpression parentPath, SqlNumberLiteral value)
            : base(parentPath)
        {
            this.Value = value;
        }

        public SqlNumberLiteral Value { get; }

        public static SqlNumberPathExpression Create(
            SqlPathExpression parentPath,
            SqlNumberLiteral value) => new SqlNumberPathExpression(parentPath, value);

        public override void Accept(SqlObjectVisitor visitor) => visitor.Visit(this);

        public override TResult Accept<TResult>(SqlObjectVisitor<TResult> visitor) => visitor.Visit(this);

        public override TResult Accept<T, TResult>(SqlObjectVisitor<T, TResult> visitor, T input) => visitor.Visit(this, input);

        public override void Accept(SqlPathExpressionVisitor visitor) => visitor.Visit(this);

        public override TResult Accept<TResult>(SqlPathExpressionVisitor<TResult> visitor) => visitor.Visit(this);
    }
}
