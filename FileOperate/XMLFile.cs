using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
namespace FileOperate
{
  public sealed  class XMLFile
    {
        XmlDocument xmlDocument;
        string _filePath;
        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath">xml文档的保存路径</param>
        /// <param name="rootElementname">根元素名称</param>
        /// <param name="virsion">xml文件版本，默认1.0版本</param>
        /// <param name="encodingName">xml文件编码规则，默认utf-8编码</param>
        public void CreateFile(string filepath,string rootElementname, string virsion="1.0",string encodingName="utf-8")
        {
            if (File.Exists(filepath))
            {
                throw new IOException(filepath + "文件已存在");
            }
           
            try
            {
                Encoding.GetEncoding(encodingName);
            }
            catch (Exception ex)
            {
                throw new Exception("找不到" + encodingName + "对应的编码格式");
            }
            xmlDocument = new XmlDocument();
            XmlNode xmlNode = xmlDocument.CreateXmlDeclaration(virsion, encodingName, null);
            xmlDocument.AppendChild(xmlNode);
            try
            {
                XmlNode _xmlNode = xmlDocument.CreateElement(rootElementname);
                xmlDocument.AppendChild(_xmlNode);
                xmlDocument.Save(filepath);
                _filePath = filepath;
            }
            catch (Exception ex)
            {
                throw ex;
            }      
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="parentNodePath">父节点路径，例如“root/root1”</param>
        /// <param name="nodeName">要添加的节点的名称</param>
        /// <param name="nodeValue">要添加的节点的值</param>
        public void CreateNode(string parentNodePath,string nodeName,string nodeValue)
        {
            try
            {
                if (xmlDocument != null)
                {
                    XmlNode xmlNode = xmlDocument.SelectSingleNode(parentNodePath);
                    if (xmlNode != null)
                    {
                        XmlElement xmlElement = xmlDocument.CreateElement(nodeName);
                        xmlElement.InnerText = nodeValue;
                        xmlNode.AppendChild(xmlElement);
                        xmlDocument.Save(_filePath);
                    }
                    else
                    {
                        throw new Exception(parentNodePath+"不存在");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 添加节点
        /// </summary>
        /// <param name="parentNode">父节点</param>
        /// <param name="nodeName">要添加的节点的名称</param>
        /// <param name="nodeValue">要添加的节点的值</param>
        public void CreateNode(XmlNode parentNode, string nodeName, string nodeValue)
        {
            try
            {
                if (xmlDocument != null)
                {               
                    XmlElement xmlElement = xmlDocument.CreateElement(nodeName);
                    xmlElement.InnerText = nodeValue;
                    parentNode.AppendChild(xmlElement);
                    xmlDocument.Save(_filePath);      
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void DeleateNode(string nodepath)
        {
            try
            {
                if (xmlDocument != null)
                {
                    XmlNode xmlNode = xmlDocument.SelectSingleNode(nodepath);
                    if (xmlNode != null)
                    {
                        xmlNode.RemoveAll();
                        xmlDocument.Save(_filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// 设置节点属性
        /// </summary>
        /// <param name="nodePath">节点路径</param>
        /// <param name="attributeName">属性名称</param>
        /// <param name="attributeValue">属性值</param>
        public void SetAttribute(string nodePath, string attributeName, string attributeValue)
        {
            try
            {
                if (xmlDocument != null)
                {
                    XmlNode xmlNode = xmlDocument.SelectSingleNode(nodePath);
                    if (xmlNode != null)
                    {
                        XmlElement xmlElement = (XmlElement)xmlNode;
                        xmlElement.SetAttribute(attributeName, attributeValue);
                        xmlDocument.Save(_filePath);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 设置节点属性
        /// </summary>
        /// <param name="xmlNode">节点引用</param>
        /// <param name="attributeName">属性名称</param>
        /// <param name="attributeValue">属性值</param>
        public void SetAttribute(XmlNode xmlNode, string attributeName, string attributeValue)
        {
            try
            {
                if (xmlDocument != null)
                {                                   
                    XmlElement xmlElement = (XmlElement)xmlNode;
                    xmlElement.SetAttribute(attributeName, attributeValue);
                    xmlDocument.Save(_filePath);
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public XmlNode GetRootNode()
        {
            XmlNode xmlNode = null;
            if (xmlDocument != null)
                xmlNode = xmlDocument.DocumentElement;
            else
                throw new Exception("xml文档句柄为空");
            return xmlNode;

        }
        public XmlNodeList GetNodeListByName(string nodename)
        {
            XmlNodeList xmlNodeList = null;
            if (xmlDocument != null)
                xmlNodeList = xmlDocument.GetElementsByTagName(nodename);
            else
                throw new Exception("xml文档句柄为空");
            return xmlNodeList;
        }
        public void  LoadFile(string filepath)
        {
            
            _filePath = filepath;
            xmlDocument = new XmlDocument();
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
            xmlReaderSettings.IgnoreComments = true;
            using (XmlReader xmlReader = XmlReader.Create(@filepath, xmlReaderSettings))
                try
                {
                    xmlDocument.Load(xmlReader);
                }
                catch (Exception ex)
                {
                    throw ex;
                }    
        }

    }
}
