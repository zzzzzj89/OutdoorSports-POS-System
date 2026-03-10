using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Outdoor.DAL; // 引用 DAL 层
using Outdoor.DAL.Models; // 引用实体

namespace Outdoor.BLL
{
    public class MemberService
    {
        // 实例化 DAL 对象
        private MemberDAL _memberDAL = new MemberDAL();

        // 1. 获取列表 (直接透传)
        public List<VipMember> GetMemberList(string keyword)
        {
            return _memberDAL.GetMembers(keyword);
        }

        // 2. 获取单个 (直接透传)
        public VipMember GetMemberById(int id)
        {
            return _memberDAL.GetMemberById(id);
        }

        // 3. 根据手机号获取 (用于收银台)
        public VipMember GetMember(string phone)
        {
            return _memberDAL.GetMemberByPhone(phone);
        }

        // 4. 保存会员 (核心逻辑：统一处理新增和修改)
        public bool SaveMember(VipMember member, out string msg)
        {
            msg = "";

            // --- 逻辑校验 A: 必填项 ---
            if (string.IsNullOrWhiteSpace(member.MemberName))
            {
                msg = "会员姓名不能为空！";
                return false;
            }
            if (string.IsNullOrWhiteSpace(member.Phone))
            {
                msg = "手机号码不能为空！";
                return false;
            }

            // --- 逻辑校验 B: 手机号查重 ---
            // 检查数据库里是不是已经有这个手机号了 (如果是修改，排除掉自己)
            if (_memberDAL.IsPhoneExist(member.Phone, member.MemberId))
            {
                msg = "该手机号已被其他会员注册！";
                return false;
            }

            // --- 判断是新增还是修改 ---
            if (member.MemberId == 0)
            {
                // === 新增模式 ===
                // 默认设置一些初始值
                member.Points = 0; // 新人积分为0
                member.Balance = 0; // 余额为0

                // 如果没填卡号，默认用手机号当卡号
                if (string.IsNullOrEmpty(member.CardNumber))
                {
                    member.CardNumber = member.Phone;
                }

                _memberDAL.AddMember(member);
            }
            else
            {
                // === 修改模式 ===
                // 为了防止覆盖掉数据库里的积分和注册时间，建议先查旧数据
                var oldMember = _memberDAL.GetMemberById(member.MemberId);
                if (oldMember != null)
                {
                    // 只更新界面上允许修改的字段
                    oldMember.MemberName = member.MemberName;
                    oldMember.Phone = member.Phone;
                    oldMember.Level = member.Level;
                    // 注意：积分 Points 和 余额 Balance 这里不更新，保持原样

                    _memberDAL.UpdateMember(oldMember);
                }
            }

            return true;
        }

        // 5. 删除会员
        public void DeleteMember(int id)
        {
            _memberDAL.DeleteMember(id);
        }

    }
}
