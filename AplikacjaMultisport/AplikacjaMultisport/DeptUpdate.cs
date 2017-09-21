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

        public bool RenameIfUnique(int index, string newName, string newShortName) {
            bool deptNamesUnique = checkDeptNamesUniquenessExceptAtIndex(index, newName, newShortName);
            if (deptNamesUnique) {
                EditedDept renamedDept = EditedDepts[index];
                if (renamedDept.Name != newName || renamedDept.ShortName != newShortName) {
                    renamedDept.Name = newName;
                    if (newShortName.Equals(string.Empty)) {
                        renamedDept.ShortName = newName;
                    } else {
                        renamedDept.ShortName = newShortName;
                    }
                    if (!renamedDept.Added) {
                        renamedDept.Renamed = true;
                        Changes = true;
                    }
                }
            }
            return deptNamesUnique;
        }

        public bool AddDeptIfUnique(string name, string shortName) {
            bool deptNamesUnique = checkDeptNamesUniqueness(name, shortName);
            if (deptNamesUnique) {
                EditedDepts.Add(new EditedDept(name, shortName));
                Permuted = true;
                Changes = true;
            }
            return deptNamesUnique;
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

        public bool checkDeptNamesUniqueness(string name, string shortName) {
            if (shortName.Equals(string.Empty)) {
                foreach (EditedDept dept in EditedDepts) {
                    if (dept.Name == name || dept.ShortName == name) {
                        return false;
                    }
                }
            } else {
                foreach (EditedDept dept in EditedDepts) {
                    if (dept.Name == name || dept.ShortName == shortName || dept.Name == shortName || dept.ShortName == name) {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool checkDeptNamesUniquenessExceptAtIndex(int index, string name, string shortName) {
            if (shortName.Equals(string.Empty)) {
                for (int i = 0; i < EditedDepts.Count; ++i) {
                    if (i != index && (EditedDepts[i].Name == name || EditedDepts[i].ShortName == name)) {
                        return false;
                    }
                }
            } else {
                for (int i = 0; i < EditedDepts.Count; ++i) {
                    if (i != index && (EditedDepts[i].Name == name || EditedDepts[i].ShortName == shortName || EditedDepts[i].Name == shortName || EditedDepts[i].ShortName == name)) {
                        return false;
                    }
                }
            }
            return true;
        }

    }

}