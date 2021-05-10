using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBM.WMQ;

namespace MQTest
{
    class AditMQHelper
    {
        public string Host { get; set; }
        public string Channel { get; set; }
        public string Port { get; set; }
        public string QM { get; set; }
        public string QueueName { get; set; }
        public int TimeOut { get; set; }

        private MQQueueManager MyQueueManager;
        private MQQueue MyQueue;
        private MQMessage MyQueueMessage;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AditMQHelper()
        {
            Host = "";
            Channel = "";
            Port = "";
            QM = "";
            QueueName = "";
            MyQueueManager = null;
            MyQueue = null;
            MyQueueMessage = null;
            TimeOut = 1000;
        }
        public AditMQHelper(string _host, string _channel, string _port, string _qm, string _queueName, int _timeout = 1000)
        {
            Host = _host;
            Channel = _channel;
            Port = _port;
            QM = _qm;
            QueueName = _queueName;
            TimeOut = _timeout;
            MyQueueManager = null;
            MyQueue = null;
            MyQueueMessage = null;
        }

        public bool Connect()
        {
            bool success = false;
            if (string.IsNullOrEmpty(Host) || string.IsNullOrEmpty(Channel) || string.IsNullOrEmpty(Port) || string.IsNullOrEmpty(QM))
            {
                throw new Exception("The parameters to connect are not set, please set the host, channel, port, and queue manager name first.");
            }

            Hashtable connectionProperties = new Hashtable();
            connectionProperties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
            connectionProperties.Add(MQC.HOST_NAME_PROPERTY, Host);
            connectionProperties.Add(MQC.CHANNEL_PROPERTY, Channel);
            connectionProperties.Add(MQC.PORT_PROPERTY, Port);
            try
            {
                MyQueueManager = new MQQueueManager(QM, connectionProperties);
                success = true;
            }
            catch (MQException exp)
            {
                throw exp;
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return success;
        }

        public bool Disconnect()
        {
            bool success = false;
            try
            {
                MyQueueMessage.ClearMessage();
                MyQueueMessage = null;

                MyQueue.Close();
                MyQueue = null;

                MyQueueManager.Disconnect();
                MyQueueManager = null;

                success = true;
            }
            catch (MQException exp)
            {
                throw exp;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return success;
        }

        public bool Get(out string _message)
        {
            bool success = false;
            _message = "";
            if (MyQueueManager == null)
            {
                if (!Connect())
                {
                    return false;
                }
            }
            if (string.IsNullOrEmpty(QueueName))
            {
                throw new Exception("Please set the queue name before put any message");
            }
            try
            {
                MyQueue = MyQueueManager.AccessQueue(QueueName, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING);
                MyQueueMessage = new MQMessage
                {
                    Format = MQC.MQFMT_STRING
                };
                var queueGetMessageOptions = new MQGetMessageOptions();
                MyQueue.Get(MyQueueMessage, queueGetMessageOptions);
                _message = MyQueueMessage.ReadString(MyQueueMessage.MessageLength);
            }
            catch (MQException exp)
            {
                throw exp;
            }
            catch (Exception exp)
            {
                throw exp;
            }
            return success;
        }

        public bool Put(string _message)
        {
            bool success = false;
            if (string.IsNullOrEmpty(QueueName))
            {
                throw new Exception("Please set the queue name before put any message");
            }
            if (MyQueueManager == null)
            {
                if (!Connect())
                {
                    return false;
                }
            }

            MyQueue = MyQueueManager.AccessQueue(QueueName, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING);
            MyQueueMessage = new MQMessage();
            MyQueueMessage.WriteString(_message);
            MyQueueMessage.Format = MQC.MQFMT_STRING;
            var queueMessageOpt = new MQPutMessageOptions();
            queueMessageOpt.Timeout = TimeOut;
            try
            {
                MyQueue.Put(MyQueueMessage, queueMessageOpt);
                success = true;
            }
            catch (MQException exp)
            {
                throw exp;
            }
            catch (Exception exp)
            {
                throw exp;
            }

            return success;
        }
    }
}
