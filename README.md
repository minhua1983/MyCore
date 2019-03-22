# 自定义web服务器
本demo是以System.Net.HttpListener为基础来做的自定义web服务器。

## 似曾相识
相信做过通信或Html5的WebSocket的朋友应该对System.Net.Sockets.TcpListener都不陌生，它是比较底层的Tcp监听器的类型，用来收发信息。
但是今天要说的是一个和它类似的类型，它叫HttpListener，顾名思义，此监听器是用来处理Http请求的。
由于Tcp协议属于比较底层的协议，而Http属于比较上层的协议，所以我们可以简单理解为HttpListener是一个经过封装的TcpListener。
TcpListener把请求报文封装为了HttpListenerRequest，把响应报文封装为了HttpListenerResponse。
TcpListener把自己又封装为HttpListener，其包含Request（即HttpListenerRequest类型）和Response（即ttpListenerResponse类型）和一些其他属性。

## 如何自定义web服务器
其实用System.Net.Sockets.TcpListener来接收Http请求也可以做web服务器，创建socket链接，接收数据（即请求报文），发出数据（即响应报文），获取ACK回执后，再断开socket等等处理步骤，只是那个工作量太繁琐了，一般公司也没人会用TcpListener来自己写web服务器
但是用System.Net.HttpListener来接收Http请求来做web服务器，就相对简单多了，在一些特殊场合可以使用自己写的web服务器。
还有一种就是基于owin规范，可以以自宿主的方式来实现web服务器。
