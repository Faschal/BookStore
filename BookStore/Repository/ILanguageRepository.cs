using BookStore.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<Language>> GetLanguages();
    }
}