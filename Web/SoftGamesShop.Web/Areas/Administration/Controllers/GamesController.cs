namespace SoftGamesShop.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SoftGamesShop.Data.Common.Repositories;
    using SoftGamesShop.Data.Models;

    [Area("Administration")]
    public class GamesController : AdministrationController
    {
        private readonly IDeletableEntityRepository<Game> gameRepository;

        public GamesController(IDeletableEntityRepository<Game> gameRepository)
        {
            this.gameRepository = gameRepository;
        }

        
        public async Task<IActionResult> Index()
        {
            return this.View(await this.gameRepository.AllWithDeleted().ToListAsync());
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var game = await this.gameRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return this.NotFound();
            }

            return this.View(game);
        }

        public IActionResult Create()
        {
            return this.View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Game game)
        {
            if (this.ModelState.IsValid)
            {
                await this.gameRepository.AddAsync(game);
                await this.gameRepository.SaveChangesAsync();
                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(game);
        }

        
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var game = this.gameRepository.All().FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return this.NotFound();
            }

            return this.View(game);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,IsDeleted,DeletedOn,Id,CreatedOn,ModifiedOn")] Game game)
        {
            if (id != game.Id)
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                try
                {
                    this.gameRepository.Update(game);
                    await this.gameRepository.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!this.GameExists(game.Id))
                    {
                        return this.NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return this.RedirectToAction(nameof(this.Index));
            }

            return this.View(game);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var game = await this.gameRepository.All()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (game == null)
            {
                return this.NotFound();
            }

            return this.View(game);
        }

        
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var game = this.gameRepository.All().FirstOrDefault(x => x.Id == id);
            this.gameRepository.Delete(game);
            await this.gameRepository.SaveChangesAsync();
            return this.RedirectToAction(nameof(this.Index));
        }

        private bool GameExists(int id)
        {
            return this.gameRepository.All().Any(e => e.Id == id);
        }
    }
}
