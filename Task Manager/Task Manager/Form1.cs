using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace Task_Manager
{
    public partial class Form1 : Form
    {
        // Connection string to your SQLite database file
        //string connectionString = "Data Source=C:/Users/oguzh/OneDrive/Bureaublad/2itf/devops/project/obama.db;Version=3;";
        string connectionString = "Data Source=C:\\database\\obama.db;Version=3;";


        string username;
        string password;

      
        
        public Form1()
        {
            InitializeComponent();
            panel1.Visible= false;
            panel2.Visible=true;

            

          

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*// Assuming the user selects the task in listBox1 and clicks button3 to delete it
            string selectedTask = listBox1.SelectedItem?.ToString();
            string username= textBox1.Text;

            if (!string.IsNullOrEmpty(selectedTask))
            {
                string deleteTaskQuery = $"DELETE FROM TasksTable WHERE Name = '{username}' AND ToDo = '{selectedTask}';";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(deleteTaskQuery, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            // Assuming you want to delete an item from listBox1 based on the selected index
                            int selectedIndex = listBox1.SelectedIndex;

                            
                                listBox1.Items.RemoveAt(selectedIndex);
                                // Additionally, if you want to remove the corresponding item from the database:
                                // Perform the deletion operation using the selected index or item content
                            
                         

                            MessageBox.Show("Task deleted successfully!");
                            // Refresh the task list (ListBox or ListView) to reflect the changes
                            // You may need to re-fetch and update the task list after deleting a task
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the task. Please try again.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
            }*/
            
            string selectedTask = listBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedTask))
            {
                string deleteTaskQuery = $"DELETE FROM TasksTable WHERE Name = '{username}' AND ToDo = '{selectedTask}';";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(deleteTaskQuery, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task deleted successfully!");
                            // Refresh the task list (ListBox or ListView) to reflect the changes
                            // You may need to re-fetch and update the task list after deleting a task
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete the task. Please try again.");
                            connection.Close();
                        }
                    }
                    connection.Close();
                }
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Please select a task to delete.");
                
            }

            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            username = textBox1.Text;
            password = textBox3.Text;

            string authenticationQuery = $"SELECT COUNT(*) FROM TasksTable WHERE Name = '{username}' AND Password = '{password}';";
            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                // Open the connection
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(authenticationQuery, connection))
                {
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        // Authentication successful
                        MessageBox.Show("Login successful!");
                        panel1.Visible = true;
                        panel2.Visible = false;
                        label1.Text = "Task manager for " + textBox1.Text;
                        string selectTasksQuery = $"SELECT ToDo, Finished FROM TasksTable WHERE Name = '{username}';";

                        using (SQLiteCommand taskCommand = new SQLiteCommand(selectTasksQuery, connection))
                        {
                            using (SQLiteDataReader reader = taskCommand.ExecuteReader())
                            {
                                listView1.Clear();
                                listBox1.Items.Clear(); // Clear ListBox before adding tasks

                                // Loop through the retrieved tasks and add them to the ListBox
                                while (reader.Read())
                                {
                                    string task = reader["ToDo"].ToString();
                                    int finished = Convert.ToInt32(reader["Finished"]);

                                    if (finished == 0)
                                    {
                                        listBox1.Items.Add(task); // Add unfinished task to ListBox
                                    }
                                    else
                                    {
                                        // Add finished task to ListView
                                        ListViewItem item = new ListViewItem(task);
                                        listView1.Items.Add(item);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // Authentication failed
                        MessageBox.Show("Invalid username or password. Please try again.");
                    }
                }
                connection.Close();
            }

            // Close the connection

            textBox1.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            button5.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*// Get the to-do task content from textBox2
            string newTask = textBox2.Text;

            
            string username = textBox1.Text; 

            string insertTaskQuery = $"INSERT INTO TasksTable (Name, ToDo, Finished) VALUES ('{username}', '{newTask}', 0);";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(insertTaskQuery, connection))
                {
                    // Execute the INSERT query to add the new task for the logged-in user
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("New task added successfully!");
                        // Refresh the task list (ListBox or ListView) to display the updated tasks
                        // You may need to re-fetch and update the task list after adding a new task
                    }
                    else
                    {
                        MessageBox.Show("Failed to add a new task. Please try again.");
                    }
                }
            }*/
            string newTask = textBox2.Text;
           

            // Assuming 'username' holds the username of the logged-in user

            string insertTaskQuery = $"INSERT INTO TasksTable (Name,  Password, ToDo, Finished) VALUES ('{username}', '{password}', '{newTask}', 0);";
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("you are trying to create an empty task please correct your mistake", "empty textbox", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(insertTaskQuery, connection))
                    {
                        // Execute the INSERT query to add the new task for the logged-in user
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("New task added successfully!");
                            // Refresh the task list (ListBox or ListView) to display the updated tasks
                            // You may need to re-fetch and update the task list after adding a new task
                            textBox2.Visible = false;
                            button5.Visible = false;
                            listBox1.Items.Add(textBox2.Text);
                            textBox2.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Failed to add a new task. Please try again.");
                        }
                    }
                    connection.Close();
                }

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*// Assuming the user selects the task in listBox1 and clicks button4 to mark it as finished
            string selectedTask = listBox1.SelectedItem?.ToString();
            string username = textBox1.Text;

            if (!string.IsNullOrEmpty(selectedTask))
            {
                string updateTaskQuery = $"UPDATE TasksTable SET Finished = 1 WHERE Name = '{username}' AND ToDo = '{selectedTask}';";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(updateTaskQuery, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task marked as finished!");
                            // Refresh the task list (ListBox or ListView) to reflect the changes
                            // You may need to re-fetch and update the task list after marking a task as finished
                        }
                        else
                        {
                            MessageBox.Show("Failed to mark the task as finished. Please try again.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a task to mark as finished.");
            }*/
            
            string selectedTask = listBox1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(selectedTask))
            {
                string updateTaskQuery = $"UPDATE TasksTable SET Finished = 1 WHERE Name = '{username}' AND ToDo = '{selectedTask}';";

                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (SQLiteCommand command = new SQLiteCommand(updateTaskQuery, connection))
                    {
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Task marked as finished!");
                            // Refresh the task list (ListBox or ListView) to reflect the changes
                            // You may need to re-fetch and update the task list after marking a task as finished
                            string selectedItem = listBox1.SelectedItem.ToString();
                            listView1.Items.Add(selectedItem);
                            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                        }
                        else
                        {
                            MessageBox.Show("Failed to mark the task as finished. Please try again.");
                        }
                    }
                    connection.Close();
                }


            }
            else
            {
                MessageBox.Show("Please select a task to mark as finished.");
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*string username = textBox1.Text;
            // Assuming button5 is clicked to delete all tasks marked as finished (Finished = 1)
            string deleteFinishedTasksQuery = $"DELETE FROM TasksTable WHERE Name = '{username}' AND Finished = 1;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(deleteFinishedTasksQuery, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        listView1.Items.Clear();
                        MessageBox.Show("Finished tasks deleted successfully!");
                        // Refresh the task list (ListBox or ListView) to reflect the changes
                        // You may need to re-fetch and update the task list after deleting finished tasks
                    }
                    else
                    {
                        MessageBox.Show("No finished tasks found to delete.");
                    }
                }
            }*/
          
            // Assuming button5 is clicked to delete all tasks marked as finished (Finished = 1)
            string deleteFinishedTasksQuery = $"DELETE FROM TasksTable WHERE Name = '{username}' AND Finished = 1;";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                using (SQLiteCommand command = new SQLiteCommand(deleteFinishedTasksQuery, connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        listView1.Items.Clear();
                        MessageBox.Show("Finished tasks deleted successfully!");
                        // Refresh the task list (ListBox or ListView) to reflect the changes
                        // You may need to re-fetch and update the task list after deleting finished tasks
                    }
                    else
                    {
                        MessageBox.Show("No finished tasks found to delete.");
                    }
                }
                connection.Close();
            }


        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel3.Visible = true; 
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string username = textBox4.Text; // Username from a TextBox
            string password = textBox5.Text; // Password from a TextBox


            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Check if the username already exists
                string checkExistingUserQuery = $"SELECT COUNT(*) FROM TasksTable WHERE Name = '{username}'";
                using (SQLiteCommand checkCommand = new SQLiteCommand(checkExistingUserQuery, connection))
                {

                    int count = Convert.ToInt32(checkCommand.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Username already exists. Please choose another username.");
                        return;
                    }
                    else
                    {
                        // If the username is unique, proceed to insert the new user
                        string insertUserQuery = $"INSERT INTO TasksTable (Name, Password, ToDo, Finished) VALUES ('{username}', '{password}','example','0')";
                        using (SQLiteCommand insertCommand = new SQLiteCommand(insertUserQuery, connection))
                        {

                            int rowsAffected = insertCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("New user created successfully!");
                                panel3.Visible=false;
                            }
                            else
                            {
                                MessageBox.Show("Failed to create a new user. Please try again.");
                            }
                        }

                        
                    }

                }
                connection.Close();
                textBox4.Clear();
                textBox5.Clear();

            }
            
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
