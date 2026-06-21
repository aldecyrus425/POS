using Microsoft.EntityFrameworkCore.Storage;
using POS.Application.Interfaces.Services;
using POS.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace POS.Application.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;

        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await _context.SaveChangesAsync();

                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null) 
            {
                await _transaction.RollbackAsync();
            }

        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
