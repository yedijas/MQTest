using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IBM.WMQ;

namespace MQTest
{
    /// <summary>
    /// Define what transport type parameter that will be used to connect.
    /// </summary>
    public enum ConnectType
    {
        SERVER,
        NONXA,
        XACLIENT,
        NONXAMANAGED
    }

    public class AditMQHelper
    {
        /// <summary>
        /// Host to connect.
        /// </summary>
        public string Host { get; set; }
        /// <summary>
        /// Channel to connect.
        /// </summary>
        public string Channel { get; set; }
        /// <summary>
        /// Port to connect
        /// </summary>
        public string Port { get; set; }
        /// <summary>
        /// Queue manager to connect.
        /// </summary>
        public string QM { get; set; }
        /// <summary>
        /// Queue name to connect.
        /// </summary>
        public string QueueName { get; set; }
        /// <summary>
        /// Time out period for message.
        /// </summary>
        public int TimeOut { get; set; }
        /// <summary>
        /// Transport type from defined enumeration for understandable types.
        /// </summary>
        public ConnectType TransportType { get; set; }

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
        /// <summary>
        /// Construct using defined parameter.
        /// </summary>
        /// <param name="_host">MQ server host.</param>
        /// <param name="_channel">MQ channel name.</param>
        /// <param name="_port">MQ channel  port.</param>
        /// <param name="_qm">MQ queue manager.</param>
        /// <param name="_queueName">MQ queue name</param>
        /// <param name="_transportType">MQ transport type (Server, client XA, non XA, non managed)</param>
        /// <param name="_timeout">Timeout for each message</param>
        public AditMQHelper(string _host, string _channel, string _port, string _qm, string _queueName, ConnectType _transportType, int _timeout = 1000)
        {
            Host = _host;
            Channel = _channel;
            Port = _port;
            QM = _qm;
            QueueName = _queueName;
            TimeOut = _timeout;
            TransportType = _transportType;
            MyQueueManager = null;
            MyQueue = null;
            MyQueueMessage = null;
        }

        /// <summary>
        /// Connect to MQ Server.
        /// </summary>
        /// <returns>True if success.</returns>
        public bool Connect()
        {
            bool success = false;
            if (string.IsNullOrEmpty(Host) || string.IsNullOrEmpty(Channel) || string.IsNullOrEmpty(Port) || string.IsNullOrEmpty(QM))
            {
                throw new Exception("The parameters to connect are not set, please set the host, channel, port, and queue manager name first.");
            }

            Hashtable connectionProperties = new Hashtable();

            switch (TransportType) // set the parameters to connect to MQ
            {

                case ConnectType.SERVER:
                    connectionProperties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_BINDINGS);
                    break;
                case ConnectType.NONXA:
                    connectionProperties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_CLIENT);
                    connectionProperties.Add(MQC.HOST_NAME_PROPERTY, Host);
                    connectionProperties.Add(MQC.CHANNEL_PROPERTY, Channel);
                    connectionProperties.Add(MQC.PORT_PROPERTY, Port);
                    break;
                case ConnectType.XACLIENT:
                    connectionProperties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_XACLIENT);
                    connectionProperties.Add(MQC.HOST_NAME_PROPERTY, Host);
                    connectionProperties.Add(MQC.CHANNEL_PROPERTY, Channel);
                    connectionProperties.Add(MQC.PORT_PROPERTY, Port);
                    break;
                case ConnectType.NONXAMANAGED:
                    connectionProperties.Add(MQC.TRANSPORT_PROPERTY, MQC.TRANSPORT_MQSERIES_MANAGED);
                    connectionProperties.Add(MQC.HOST_NAME_PROPERTY, Host);
                    connectionProperties.Add(MQC.CHANNEL_PROPERTY, Channel);
                    connectionProperties.Add(MQC.PORT_PROPERTY, Port);
                    break;
            }
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
        /// <summary>
        /// Disconnect from MQ server and release all resources used.
        /// </summary>
        /// <returns>True if success.</returns>
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
                GC.Collect();
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
        /// <summary>
        /// Get current message in server queue.
        /// </summary>
        /// <param name="_message">Message result from server.</param>
        /// <returns>True if successfully get the message.</returns>
        public bool Get(out string _message)
        {
            bool success = false;
            _message = "";
            if (MyQueueManager == null) // check connection
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
                // accessing
                MyQueue = MyQueueManager.AccessQueue(QueueName, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING);
                MyQueueMessage = new MQMessage
                {
                    Format = MQC.MQFMT_STRING
                };
                var queueGetMessageOptions = new MQGetMessageOptions();
                MyQueue.Get(MyQueueMessage, queueGetMessageOptions); // get attempt
                _message = MyQueueMessage.ReadString(MyQueueMessage.MessageLength); // dumping to string
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
        /// <summary>
        /// Put a message in server queue.
        /// </summary>
        /// <param name="_message">Message to be put in server.</param>
        /// <returns>True if sucessfully put the message.</returns>
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
