using System.Collections.Generic;

namespace AppMultisport {

    public class DeptUpdate {

        public List<EditedDept> EditedDepts { get; private set; } = new List<EditedDept>();
        public List<EditedDept> DeletedDepts { get; private set; } = new List<EditedDept>();
        public bool Permuted { get; private set; } = false;

        public DeptUpdate(List<Dept> originalDepts) {
            foreach (Dept originalDept in originalDepts) {
                EditedDepts.Add(new EditedDept(originalDept));
            }
        }

        public void Rename(int index, string newName) {
            EditedDept renamedDept = EditedDepts[index];
            if (renamedDept.Name != newName) {
                renamedDept.Name = newName;
                if (!renamedDept.Added) {
                    renamedDept.Renamed = true;
                }
            }
        }

        public void AddDept() {
            EditedDepts.Add(new EditedDept("Nowy dział"));
            Permuted = true;
        }

        public void DeleteDept(int index) {
            EditedDept deletedDept = EditedDepts[index];
            EditedDepts.RemoveAt(index);
            if (!deletedDept.Added) {
                DeletedDepts.Add(deletedDept);
            Permuted = true;
            }
        }

        public void MoveUp(int index) {
            if (index != 0) {
                EditedDept previousDept = EditedDepts[index - 1];
                EditedDepts[index - 1] = EditedDepts[index];
                EditedDepts[index] = previousDept;
                Permuted = true;
            }
        }

        public void MoveDown(int index) {
            if (index != EditedDepts.Count) {
                EditedDept nextDept = EditedDepts[index + 1];
                EditedDepts[index + 1] = EditedDepts[index];
                EditedDepts[index] = nextDept;
                Permuted = true;
            }
        }
        
    }

}