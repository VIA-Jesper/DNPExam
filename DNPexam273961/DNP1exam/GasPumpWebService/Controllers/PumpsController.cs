using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GasPump;
using GasPumpWebService.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GasPumpWebService.Controllers
{
    [ApiController]
    public class PumpsController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly Pump pump;

        public PumpsController(DatabaseContext context, Pump pump)
        {
            _context = context;
            this.pump = pump;
        }






        // /gaspump/CostOfFullTank?size=x (GET) 
        [HttpGet]
        [Route("/gaspump/CostOfFullTank")]
        public Task<ActionResult<double>> GetCostOfFullTank(decimal size)
        {
            return Task.FromResult<ActionResult<double>>(pump.CostOfFullTank(size));
        }


        // /gaspump/FillTank?amount=x (GET) 
        [HttpGet]
        [Route("/gaspump/FillTank")]
        public async Task<ActionResult<double>> GetFillTank(decimal amount)
        {
            try
            {
                var usageHistory = new PumpUsageHistory() { WithdrawDate = DateTime.Now, GasWithdrawAmount = amount, RemainingGasInPump = pump.pumpCapacity - amount };
                var result = pump.FillTank(amount);
                await _context.UsageHistories.AddAsync(usageHistory);
                await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception e)
            {
                return new ActionResult<double>(BadRequest(e.Message));
            }

        }

        // /gaspump/FillPump (POST)
        [HttpPost]
        [Route("/gaspump/FillPump")]
        public async Task<ActionResult<DateTime>> PostFillPump()
        {
            var fillHistory = new PumpFillHistory() {FillDate = DateTime.Now};
            await _context.FillHistories.AddAsync(fillHistory);
            await _context.SaveChangesAsync();

            return pump.FillPump();
        }


        // /gaspump/FillTank/history (GET) 
        [HttpGet]
        [Route("/gaspump/FillTank/history")]
        public async Task<ActionResult<List<PumpUsageHistory>>> GetAllFillTank()
        {

            var result = _context.UsageHistories.ToList();

            return await _context.UsageHistories.ToListAsync();
        }

        // /gaspump/FillPump/history (GET)
        [HttpGet]
        [Route("/gaspump/FillPump/history")]
        public async Task<ActionResult<List<PumpFillHistory>>> GetAllFillPump()
        {
            return await _context.FillHistories.ToListAsync();
        }


    }
}
