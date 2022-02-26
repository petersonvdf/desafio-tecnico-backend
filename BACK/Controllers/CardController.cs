using System;
using BACK.Data;
using BACK.Models;
using Back.Filters;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BACK.Controllers
{
    [Authorize]
    [ApiController]
    [Route("cards")]
    public class CardController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Card>>> Get([FromServices] DataContext context)
        {
            return await context.Cards.AsNoTracking().ToListAsync();
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Card>> Post(
            [FromServices] DataContext context,
            [FromBody] Card model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            try
            {
                context.Cards.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o card" });
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ServiceFilter(typeof(ConsoleLogActionFilter))]
        public async Task<ActionResult<Card>> Put(
            [FromServices] DataContext context,
            Guid id,
            [FromBody] Card model)
        {
            if (id != model.Id) return NotFound(new { message = "Card não encontrado" });

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var oldCard = await context.Cards.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            try
            {
                context.Entry<Card>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                SetResponseOldInfo(oldCard);
                return model;
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar o card" });
            }
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        [ServiceFilter(typeof(ConsoleLogActionFilter))]
        public async Task<ActionResult<List<Card>>> Delete(
            [FromServices] DataContext context,
            Guid id)
        {
            var card = await context.Cards.FirstOrDefaultAsync(x => x.Id == id);

            if (card == null) return NotFound(new { message = "Card não encontrado" });

            try
            {
                context.Cards.Remove(card);
                await context.SaveChangesAsync();
                SetResponseOldInfo(card);
                return await context.Cards.AsNoTracking().ToListAsync();
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover o card" });
            }
        }

        private void SetResponseOldInfo(Card oldCard)
        {
            Response.HttpContext.Items.Add("oldCard", oldCard);
        }
    }
}
