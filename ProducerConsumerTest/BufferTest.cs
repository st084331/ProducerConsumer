using ProducerConsumer;

namespace ProducerConsumerTests
{
    public class BufferTests
    {
        private Buffer<string> buffer;

        [SetUp]
        public void Setup()
        {
            buffer = new Buffer<string>();
        }

        [Test]
        public void IsEmptyTest()
        {
            Assert.That(buffer.IsEmpty, Is.True);
            buffer.Push("hello");
            Assert.That(buffer.IsEmpty, Is.False);
            buffer.Pop();
            Assert.That(buffer.IsEmpty, Is.True);
        }

        [Test]
        public void PushPopTest()
        {
            buffer.Push("first");
            buffer.Push("second");
            var first = buffer.Pop();
            Assert.That(first, Is.EqualTo("first"));
            buffer.Push("third");
            var second = buffer.Pop();
            var third = buffer.Pop();
            Assert.That(second, Is.EqualTo("second"));
            Assert.That(third, Is.EqualTo("third"));
        }
    }
}