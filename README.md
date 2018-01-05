# 使用C#进行图像处理
## 前言
之前一直认为图像处理是一件很高大上的事情，在一门选修课的课上遇到一个图像处理的作业，上手几个简单的图像处理的算法，也算是入了个最简单的门。
界面简单而又丑陋，代码命名也比较随意，大家重点关注算法就好
在这里一共实现了**暗角**、**降低亮度**、**灰度**、**浮雕**、**马赛克**、**扩散**六个算法。


## 界面设计
这里使用的是VS2010，新建C#工程之后。在界面上画出
- 2个pictureBox作为显示的图片的控件。
- 6个button作为不同效果的触发器，
- 2个button作为文件打开和保存的触发器，
- 1个label负责展示运行时间。

![这里写图片描述](http://img.blog.csdn.net/20180105192521523?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvd2Noc3RyaWZl/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

## 文件打开与保存
这里主要就是调用了openFileDialog和openFileDialog，不具体说。

```
## 添加暗角
暗角就是在图像的四角添加逐渐变黑的一个圈。
### 基本步骤：

 1. 计算顶点与中心的距离maxDistance
 2. 计算每个像素点与中心的距离distance
 3. 计算factor = distance / maxDistance
 4. 将当前像素点的颜色设置为 原颜色 * （1-factor）
### 效果图
![这里写图片描述](http://img.blog.csdn.net/20180105193732103?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvd2Noc3RyaWZl/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)


## 降低亮度
### 基本步骤
降低亮度就是设置当前像素的颜色为原来的一个小于1的系数，要注意各颜色的分量不能超过255。这里我们选取0.6作为系数。
### 效果图
![这里写图片描述](http://img.blog.csdn.net/20180105194022793?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvd2Noc3RyaWZl/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

## 去色
### 基本步骤
去色也就是要把照片灰化，将照片的RGB调节为灰色的。
具体的就是要把当前像素点的颜色按下面的公式的调整
gary = 0.3 * R + 0.59 * G + 0.11 * B
### 效果图
![这里写图片描述](http://img.blog.csdn.net/20180105194541506?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvd2Noc3RyaWZl/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

## 浮雕
### 基本步骤
浮雕效果就是把RGB三个颜色取反。
具体的实现用255-当前颜色的分量
### 效果图
![这里写图片描述](http://img.blog.csdn.net/20180105195157537?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvd2Noc3RyaWZl/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

## 马赛克
### 基本步骤
马赛克的基本思想就是把一个像素点周围的点的像素取个平均，然后把这些像素点的颜色设为这个平均值。
周围的像素点取的越多，马克赛的效果也就越明显。
### 效果图
![这里写图片描述](http://img.blog.csdn.net/20180105195448789?watermark/2/text/aHR0cDovL2Jsb2cuY3Nkbi5uZXQvd2Noc3RyaWZl/font/5a6L5L2T/fontsize/400/fill/I0JBQkFCMA==/dissolve/70/gravity/SouthEast)

## 扩散效果
### 基本步骤
类似于水墨在纸上的扩散。随机挑选一个临近的像素，将其设为自身颜色。
这里一定注意要随机取周围的像素。
