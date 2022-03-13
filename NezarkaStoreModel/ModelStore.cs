using System;
using System.Collections.Generic;
using System.Text;

using System.IO;

namespace NezarkaBookstoreWeb {

    public interface IBookstoreFactory<T>
    {
        T CreateInstance();
    }

    public class DefaultFactory<T>: IBookstoreFactory<T> where T : new()
    {
        public static readonly DefaultFactory<T> Instance = new DefaultFactory<T>();
        private DefaultFactory() { }
        public T CreateInstance() => new T();
    }


    public class ModelStore {
        private List<Book> books = new List<Book>();
        private List<Customer> customers = new List<Customer>();

        public IList<Book> GetBooks() {
            return books;
        }

        public IList<Customer> GetCustomers() {
            return customers;
        }

		public Book GetBook(int id) {
			return books.Find(b => b.Id == id);
		}

		public Customer GetCustomer(int id) {
			return customers.Find(c => c.Id == id);
		}
        public static ModelStore LoadFrom(TextReader reader) => LoadFrom(reader, DefaultFactory<Book>.Instance, DefaultFactory<Customer>.Instance);
		public static ModelStore LoadFrom(TextReader reader, IBookstoreFactory<Book> bookFactory, IBookstoreFactory<Customer> customerFactory) {
			var store = new ModelStore();

			try {
				if (reader.ReadLine() != "DATA-BEGIN") {
					return null;
				}
				while (true) {
					string line = reader.ReadLine();
					if (line == null) {
						return null;
					} else if (line == "DATA-END") {
						break;
					}

					string[] tokens = line.Split(';');
					switch (tokens[0]) {
						case "BOOK":
                            var book = bookFactory.CreateInstance();
                            book.Id = int.Parse(tokens[1]);
                            book.Title = tokens[2];
                            book.Author = tokens[3];
                            book.Price = decimal.Parse(tokens[4]);
                            store.books.Add(book);
                            break;
						case "CUSTOMER": {								
                                var customer = customerFactory.CreateInstance();
                                customer.Id = int.Parse(tokens[1]);
                                customer.FirstName = tokens[2];
                                customer.LastName = tokens[3];
                                customer.DateJoined = null;
                                if (tokens.Length >= 6) {
									customer.DateJoined = new DateTime(int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]));
								}
								store.customers.Add(customer);
								break;
							}
						case "CART-ITEM": {
								var customer = store.GetCustomer(int.Parse(tokens[1]));
								if (customer == null) {
									return null;
								}
								customer.ShoppingCart.Items.Add(new ShoppingCartItem {
									BookId = int.Parse(tokens[2]), Count = int.Parse(tokens[3])
								});
								break;
							}
						default:
							return null;
					}
				}
			} catch (Exception ex) {
				if (ex is FormatException || ex is IndexOutOfRangeException) {
					return null;
				}
				throw;
			}

			return store;
		}
	}

}