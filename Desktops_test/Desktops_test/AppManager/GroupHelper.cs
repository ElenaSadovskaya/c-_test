using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desktops_test
{
    public class GroupHelper : HelperBase
    {
        public static string groupEditWin = "Group editor";
        public static string groupDeleteWin = "Delete group";
        public GroupHelper(ApplicationManager manager) : base(manager) { }
        
        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialog();
            string count = aux.ControlTreeView(groupEditWin, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(groupEditWin, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#" + i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupDialog();
            return list;
        }

        public void RemoveGroup(int v)
        {
            OpenGroupsDialog();
            SelectDeleteGroup(v);
            PressDeleteButton();
            ConfirmGroupDeleting();
            CloseGroupDialog();
        }

        public void PressDeleteButton()
        {
            aux.ControlClick(groupEditWin, "", "WindowsForms10.BUTTON.app.0.2c908d51");
        }

        public void SelectDeleteGroup(int v)
        {
            aux.ControlClick(groupEditWin, "", aux.ControlTreeView(groupEditWin, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#0|#" + v, ""));
            
        }

        public void ConfirmGroupDeleting()
        {
            aux.WinWait(groupDeleteWin);
            aux.ControlClick(groupDeleteWin, "", "WindowsForms10.BUTTON.app.0.2c908d53");
        }

        public void AddNewGroup(GroupData newGroup)
        {
            OpenGroupsDialog();
            aux.ControlClick(groupEditWin, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{Enter}");
            CloseGroupDialog();

        }

        public void CloseGroupDialog()
        {
            aux.ControlClick(groupEditWin, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void OpenGroupsDialog()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(groupEditWin);
        }

        public GroupHelper CheckGroupExist()
        {
            OpenGroupsDialog();
            string count = aux.ControlTreeView(groupEditWin, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            if (int.Parse(count) > 0)
            {
            }
            else
            {
                AddNewGroup(new GroupData("1"));
            }
            return this;
        }
    }

}
