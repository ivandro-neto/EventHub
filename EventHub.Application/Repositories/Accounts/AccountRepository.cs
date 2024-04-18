using EventHub.Exceptions;
using EventHub.Infrastructure;
using EventHub.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace EventHub.Application.Repositories
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
            await _context.Account.AddAsync(account);
            await _context.SaveChangesAsync();
        }

       

        public async Task DeleteAccountAsync(Guid id)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    // Encontra a conta pelo ID
                    var account = await _context.Account.Include(a => a.CreatedEvents).FirstOrDefaultAsync(ac => ac.ID_Account == id);
                    if (account is null)
                    {
                        throw new NotFoundException($"Conta com o ID {id} não encontrada.");
                    }

                    // Remove os eventos associados à conta
                    _context.Event.RemoveRange(account.CreatedEvents);

                    // Remove a conta
                    _context.Account.Remove(account);

                    // Salva as alterações no banco de dados
                    await _context.SaveChangesAsync();

                    // Commit da transação
                    await transaction.CommitAsync();
                }
                catch
                {
                    // Em caso de erro, faz rollback da transação
                    await transaction.RollbackAsync();
                    throw new Exception("Ocorreu um erro ao excluir a conta.");
                }
            }
        }

        public async Task<List<Account>> GetAllAsync()
        {
           
            return await _context.Account
        .Include(account => account.CreatedEvents) 
        .ToListAsync(); 
        }

        public async Task<Account> GetByIdAsync(Guid id)
        {
            var account = await _context.Account.Include(evnt=> evnt.CreatedEvents).FirstOrDefaultAsync(ac => ac.ID_Account == id);
            if(account is null)
            {
                throw new NotFoundException("There is no any account with provided id.");
            }
            return account;
        }

        public async Task UpdateAccountAsync(Account account)
        {
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
