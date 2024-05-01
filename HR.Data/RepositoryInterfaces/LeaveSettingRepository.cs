using HR.Data.Abstractions;
using HR.Data.Entities;
using HR.Data.Enums;
using HR.Data.RepositoryInterfaces.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.Data.RepositoryInterfaces
{
    public class LeaveSettingRepository : IRepositoryBase<LeaveSetting>, ILeaveSettingRepository
    {
        protected HumanResourcesContext _ctx { get; set; }
        public LeaveSettingRepository(HumanResourcesContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<LeaveSetting> Create(LeaveSetting entity)
        {
            await _ctx.LeaveSettings.AddAsync(entity);
            return entity;
        }

        public async Task Delete(int id)
        {
            _ctx.LeaveSettings.Remove(await this.FindById(id));
        }

        public async Task<LeaveSetting> FindById(int id)
        {
            return await _ctx.LeaveSettings.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<LeaveSetting>> GetAll()
        {
            return await _ctx.LeaveSettings.ToListAsync();
        }

        public void Update(LeaveSetting entity)
        {
            _ctx.LeaveSettings.Update(entity);
        }

        public async Task<List<LeaveSetting>> GetLeaveSettingsByLeaveTypeId(int leaveTypeId)
        {
            return await _ctx.LeaveSettings.Where(ls=> (int)ls.LeaveTypeId==leaveTypeId).ToListAsync();
        }
    }
}
