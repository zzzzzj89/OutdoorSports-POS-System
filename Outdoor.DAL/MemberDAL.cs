using Outdoor.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Outdoor.DAL
{
    public class MemberDAL
    {
        // 1. 查询会员列表 (支持按姓名或手机号模糊搜索)
        public List<VipMember> GetMembers(string keyword = "")
        {
            using (var context = new OutdoorContext())
            {
                var query = context.VipMembers.AsQueryable();

                if (!string.IsNullOrEmpty(keyword))
                {
                    // 只要姓名或手机号包含关键词，就查出来
                    query = query.Where(m => m.MemberName.Contains(keyword) || m.Phone.Contains(keyword));
                }

                // 按注册时间倒序排列 (最新的在最上面)
                return query.OrderByDescending(m => m.RegisterDate).ToList();
            }
        }

        // 2. 根据ID获取单个会员 (用于修改时回显数据)
        public VipMember GetMemberById(int id)
        {
            using (var context = new OutdoorContext())
            {
                return context.VipMembers.Find(id);
            }
        }

        // 3. 根据手机号获取会员 (用于收银台查询，或注册查重)
        public VipMember GetMemberByPhone(string phone)
        {
            using (var context = new OutdoorContext())
            {
                return context.VipMembers.FirstOrDefault(m => m.Phone == phone);
            }
        }

        // 4. 新增会员
        public void AddMember(VipMember member)
        {
            using (var context = new OutdoorContext())
            {
                // 设置注册时间为当前
                member.RegisterDate = DateTime.Now;
                context.VipMembers.Add(member);
                context.SaveChanges();
            }
        }

        // 5. 修改会员
        public void UpdateMember(VipMember member)
        {
            using (var context = new OutdoorContext())
            {
                // EF Core 的 Update 方法会自动根据主键ID去更新字段
                context.VipMembers.Update(member);
                context.SaveChanges();
            }
        }

        // 6. 删除会员
        public void DeleteMember(int id)
        {
            using (var context = new OutdoorContext())
            {
                var member = context.VipMembers.Find(id);
                if (member != null)
                {
                    context.VipMembers.Remove(member);
                    context.SaveChanges();
                }
            }
        }

        // 7. 检查手机号是否存在 (排除自己，用于修改时防止和别人重复)
        // excludeId: 如果是修改，排除自己的ID；如果是新增，传0
        public bool IsPhoneExist(string phone, int excludeId = 0)
        {
            using (var context = new OutdoorContext())
            {
                return context.VipMembers.Any(m => m.Phone == phone && m.MemberId != excludeId);
            }
        }

    }
}
