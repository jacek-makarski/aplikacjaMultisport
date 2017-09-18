using System.Collections.Generic;

namespace AppMultisport {

    public class DeptUpdate {

        public List<EditedDept> EditedDepts { get; private set; } = new List<EditedDept>();
        public List<EditedDept> DeletedDepts { get; private set; } = new List<EditedDept>();
        public bool Permuted { get; private set; } = false;
        public bool Changes { get; private set; } = false;

        public DeptUpdate(List<Dept> originalDepts) {
            foreach (Dept originalDept in originalDepts) {
                EditedDepts.Add(new EditedDept(originalDept));
            }
        }

        public void Rename(int index, string newName, string newShortName) {
            EditedDept renamedDept = EditedDepts[index];
            if (renamedDept.Name != newName || renamedDept.ShortName != newShortName) {
                renamedDept.Name = newName;
                renamedDept.ShortName = newShortName;
                if (!renamedDept.Added) {
                    renamedDept.Renamed = true;
                    Changes = true;
                }
            }
        }

        public void AddDept(string name, string shortName) {
            EditedDepts.Add(new EditedDept(name, shortName));
            Permuted = true;
            Changes = true;
        }

        public void DeleteDept(int index) {
            EditedDept deletedDept = EditedDepts[index];
            EditedDepts.RemoveAt(index);
            if (!deletedDept.Added) {
                DeletedDepts.Add(deletedDept);
                Permuted = true;
                Changes = true;
            }
        }

        public void MoveUp(int index) {
            if (index != 0) {
                EditedDept previousDept = EditedDepts[index - 1];
                EditedDepts[index - 1] = EditedDepts[index];
                EditedDepts[index] = previousDept;
                Permuted = true;
                Changes = true;
            }
        }

        public void MoveDown(int index) {
            if (index != EditedDepts.Count) {
                EditedDept nextDept = EditedDepts[index + 1];
                EditedDepts[index + 1] = EditedDepts[index];
                EditedDepts[index] = nextDept;
                Permuted = true;
                Changes = true;
            }
        }
        
    }

}