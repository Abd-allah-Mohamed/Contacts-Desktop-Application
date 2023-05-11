using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Forms;

namespace contact
{
    public class contact
    {
        public string name { get; set; }
        public string number { get; set; }
        public contact next { get; set; }
    }
    public class PhoneDirectory
    {
        string TempData;
        contact head = null, newcontact;
        public void load(string name, string number)
        {
            newcontact = new contact();
            newcontact.name = name;
            newcontact.number = number;
            if (head == null)
            {
                head = newcontact;
            }
            else
            {
                contact p = head;
                while (p.next != null)
                {
                    p = p.next;
                }
                p.next = newcontact;
                newcontact.next = null;
            }
        }
        public string[] DataToSave()
        {
            contact p = head;
            int count = 0;
            //count
            while (p != null)
            {
                p = p.next;
                count += 2;
            }
            string[] data = new string[count];
            //fill the array
            p = head;
            count = 0;
            while (p != null)
            {
                data[count] = p.name;
                data[count + 1] = p.number;
                p = p.next;
                count += 2;
            }
            return data;
        }
        static public int compare(string s1, string s2)
        {
            int range = 0;
            char[] c1 = s1.ToCharArray();
            char[] c2 = s2.ToCharArray();
            if (s1.Length > s2.Length)
                range = s2.Length;
            else
                range = s1.Length;
            for (int i = 0; i < range; i++)
            {
                if (c1[i] > c2[i])
                    return 1;
                else if (c2[i] > c1[i])
                    return -1;
            }
            if (s1.Length > s2.Length)
                return 1;
            else if (s2.Length > s1.Length)
                return -1;
            else
                return 0;
        }
        public bool duplicate(string data)
        {
            contact p = head;
            if (head == null)
            {
                return false;
            }
            else
            {
                while (p != null)
                {
                    if (data == p.name || data == p.number)
                    {
                        return true;
                    }
                    p = p.next;
                }
                return false;
            }
        }
        public void addcontact(string name, string number)
        {
            newcontact = new contact();
            newcontact.name = name;
            newcontact.number = number;
            newcontact.next = null;
            if (head == null)
            {
                head = newcontact;
                return;
            }
            else
            {
                if (compare(head.name, newcontact.name) == 1)
                {
                    newcontact.next = head;
                    head = newcontact;
                    return;
                }
                bool notadded = true;
                contact p = head;
                while (notadded)
                {
                    if (p.next != null)
                    {
                        if ((compare(p.next.name, newcontact.name) == -1))
                        {
                            p = p.next;
                        }
                        else
                        {
                            newcontact.next = p.next;
                            p.next = newcontact;
                            notadded = false;
                        }
                    }
                    else
                    {
                        p.next = newcontact;
                        notadded = false;
                    }
                }
            }
        }
        public void searchcontact(string data_to_serch_for, Label l1)
        {
            contact p = head;
            string search = data_to_serch_for;
            if (isempty())
            {
                l1.Text = "the contact list is empty";
                return;
            }
            while (p != null)
            {
                if (search == p.name || search == p.number)
                {
                    l1.Text = "Name : " + p.name + " \nNumber : " + p.number;
                    return;
                }
                p = p.next;
            }
            l1.Text = "contact not found";
        }
        public void deletecontact(string data_to_delete)
        {
            if (head == null)
            {
                return;
            }
            string delete = data_to_delete;
            contact p = head;
            if (delete == head.name || delete == head.number)
            {
                head = head.next;
                return;
            }
            else
            {
                while (p != null)
                {
                    if (delete == p.next.name || delete == p.next.number)
                    {
                        p.next = p.next.next;
                        return;
                    }
                    p = p.next;
                }
            }
        }
        public void editcontact(string data_to_edit, string newdata, bool name)
        {
            contact p = head;
            string search = data_to_edit;

            if (head == null)
            {
                MessageBox.Show("data not found!");
                return;
            }
            else
            {
                if (name)
                {
                    while (p != null)
                    {
                        if (search == p.name || search == p.number)
                        {
                            TempData = p.number;
                            string newname = newdata;
                            deletecontact(data_to_edit);
                            addcontact(newname, TempData);
                            return;
                        }
                        p = p.next;
                    }
                }
                else
                {
                    while (p != null)
                    {
                        if (search == p.name || search == p.number)
                        {
                            TempData = p.name;
                            string newnumber = newdata;
                            deletecontact(data_to_edit);
                            addcontact(TempData, newnumber);
                            return;
                        }
                        p = p.next;
                    }
                }
                MessageBox.Show("data not found!");
            }
        }
        public void editcontact(string data_to_edit, string newdata, string newdata2)
        {
            contact p = head;
            string search = data_to_edit;
            string newname = newdata;
            string newnumber = newdata2;

            if (head == null)
            {
                MessageBox.Show("data not found!");
                return;
            }
            else
            {
                while (p != null)
                {
                    if (search == p.name || search == p.number)
                    {
                        deletecontact(search);
                        addcontact(newname, newnumber);
                        return;
                    }
                    p = p.next;
                }
                MessageBox.Show("data not found!");
            }
        }
        public void show(ListBox lb)
        {
            lb.Items.Clear();
            contact p = head;
            while (p != null)
            {
                lb.Items.Add(p.name);
                p = p.next;
            }
        }
        public bool isempty()
        {
            if (head == null)
                return true;
            else
                return false;
        }
        public void clear()
        {
            if (head == null)
                return;
            else
            {
                head = null;
                return;
            }
        }
        public string getnum(string name)
        {
            contact p = head;
            string search = name;
            while (p != null)
            {
                if (search == p.name)
                {
                    return p.number.ToString();
                }
                p = p.next;
            }
            return null;
        }
    }
}