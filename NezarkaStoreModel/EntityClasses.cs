using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace NezarkaBookstoreWeb {

	public class Book {
		public int Id { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public decimal Price { get; set; }
	}

	public class Customer {
		private ShoppingCart shoppingCart;

		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime? DateJoined { get; set; }

		public ShoppingCart ShoppingCart {
			get {
				if (shoppingCart == null) {
					shoppingCart = new ShoppingCart();
				}
				return shoppingCart;
			}
			set {
				shoppingCart = value;
			}
		}
    }

	public class ShoppingCartItem {
		public int BookId { get; set; }
		public int Count { get; set; }
	}

	public class ShoppingCart {
		public int CustomerId { get; set; }
		public List<ShoppingCartItem> Items = new List<ShoppingCartItem>();

		public void Add(Book book) {
			var item = Items.Find(i => i.BookId == book.Id);
			if (item == null) {
				item = new ShoppingCartItem { BookId = book.Id, Count = 0 };
				Items.Add(item);
			}
			item.Count++;
		}

		public bool Remove(Book book) {
			var item = Items.Find(i => i.BookId == book.Id);
			if (item == null) {
				return false;
			} else {
				item.Count--;
				if (item.Count == 0) {
					Items.Remove(item);
				}
				return true;
			}
		}
	}

}