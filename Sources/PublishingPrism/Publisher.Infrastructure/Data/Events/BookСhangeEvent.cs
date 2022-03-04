using Prism.Events;
using Publisher.Infrastructure.Interfaces.Models;

namespace Publisher.Infrastructure.Data.Events
{
    public class BookСhangeEvent : PubSubEvent<IBook>
    { }
}