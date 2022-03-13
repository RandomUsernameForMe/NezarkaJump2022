using NezarkaBookstoreWeb;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace JumpingPlatformGame
{	
	public partial class MainForm : Form
	{
		private const int LabelWidth = 30;
		private const int LabelHeight = 30;

		private List<Entity> entities = new List<Entity>();
		private List<Label> entityLabels = new List<Label>();
		private Random random = new Random();
        ModelStore model = ModelStore.LoadFrom(new StreamReader("NezarkaSummer.in"),DefaultFactory<Book>.Instance,new CustomerViewModelFactory());

		public MainForm()
		{
			InitializeComponent();
            customer_listBox.DataSource = model.GetCustomers();
		}

		private void RegisterEntity(Entity entity)
		{
			entities.Add(entity);

			entity.Location = new WorldPoint
			{
				X = random.Next(LabelWidth / 2, worldPanel.Width - LabelWidth / 2).Meters(),
				Y = (LabelWidth / 2).Meters()
			};

			var label = new Label();
			label.AutoSize = false;
			label.Width = LabelWidth;
			label.Height = LabelHeight;
			label.BackColor = entity.Color;
			label.SetLocation(entity, worldPanel.Height);
			entityLabels.Add(label);
			worldPanel.Controls.Add(label);

			if (entity is MovableEntity movableEntity)
			{
				movableEntity.Horizontal.LowerBound = (LabelWidth / 2).Meters();
				movableEntity.Horizontal.UpperBound = (worldPanel.Width - LabelWidth / 2).Meters();
				movableEntity.Horizontal.Speed = 160.MeterPerSeconds();
			}

			if (entity is MovableJumpingEntity jumpingEntity)
			{
				jumpingEntity.Vertical.LowerBound = (LabelHeight / 2).Meters();
				jumpingEntity.Vertical.UpperBound = (worldPanel.Height - LabelHeight / 2).Meters();
				jumpingEntity.Vertical.Speed = (-200).MeterPerSeconds();

				var jumpButton = new Button();
				jumpButton.Text = entity.ToString();
				jumpButton.Tag = entity;
				jumpButton.Click += JumpButton_Click;
				jumpingPanel.Controls.Add(jumpButton);
			}
		}

		private void JumpButton_Click(object sender, EventArgs e)
		{
			var entity = (sender as Button)?.Tag as MovableJumpingEntity
				?? throw new ArgumentException($"Must be a Button with Tag set to a {nameof(MovableJumpingEntity)}", nameof(sender));

			entity.Vertical.Speed = Math.Abs(entity.Vertical.Speed.Value).MeterPerSeconds();
		}

		DateTime lastTick = DateTime.Now;

		private void updateTimer_Tick(object sender, EventArgs e)
		{
			var now = DateTime.Now;
			var deltaSeconds = (now - lastTick).TotalSeconds.Seconds();
			lastTick = now;

			for (int i = 0; i < entities.Count; i++)
			{
				entities[i].Update(deltaSeconds);
				entityLabels[i].SetLocation(entities[i], worldPanel.Height);
			}
		}

        private void button1_Click(object sender, EventArgs e)
        {
            RegisterEntity(new CustomerEntity((Customer)customer_listBox.SelectedItem));
        }
	}

	static class ControlExtensions
	{
		public static void SetLocation(this Control control, Entity entity, int worldHeight)
		{
			control.Left = (int)entity.Location.X.Meters - control.Width / 2;
			control.Top = worldHeight - (int)entity.Location.Y.Meters - control.Height / 2;
		}
	}

    class CustomerViewModelFactory : IBookstoreFactory<Customer>
    {
        public Customer CreateInstance() => new CustomerViewModel();
    }


    class CustomerViewModel : Customer
    {
        public override string ToString()
        {
            var result = FirstName + " " + LastName + " since ";
            if (DateJoined == null)
            {
                result += "always";
            }
            else
            {
                result += "year " + DateJoined.Value.Year;
            }
            return result;
        }
    }




}
