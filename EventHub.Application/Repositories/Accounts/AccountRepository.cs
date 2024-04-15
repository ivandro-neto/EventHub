using EventHub.Infrastructure;
using EventHub.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHub.Application.Repositories.Accounts
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(Guid id);
        Task CreateAccountAsync(Account account);
        Task UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(Guid id);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly EventHubDBContext _context;
        public AccountRepository(EventHubDBContext eventHubDBContext)
        {
            _context = eventHubDBContext;
        }
        public async Task CreateAccountAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(Guid id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Encontra a conta pelo ID
                    var account = await _context.Accounts.Include(a => a.Events).FirstOrDefaultAsync(ac => ac.AccountID == id);
                    if (account == null)
                    {
                        throw new ArgumentException($"Conta com o ID {id} não encontrada.");
                    }

                    // Remove os eventos associados à conta
                    _context.Events.RemoveRange(account.Events);

                    // Remove a conta
                    _context.Accounts.Remove(account);

                    // Salva as alterações no banco de dados
                    await _context.SaveChangesAsync();

                    // Commit da transação
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Em caso de erro, faz rollback da transação
                    await transaction.RollbackAsync();
                    throw new Exception("Ocorreu um erro ao excluir a conta.", ex);
                }
            }
        }

        public async Task<List<Account>> GetAllAsync()
        {
           
            return await _context.Accounts
        .Include(account => account.Events) 
        .ToListAsync(); 
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            return await _context.Accounts.Include(evnt=> evnt.Events).FirstOrDefaultAsync(ac => ac.AccountID == id);
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
