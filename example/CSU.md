---
name: 测试人
id: 1234567890
teacher: 张某
department: 某学院
main_title: 一个看似很厉害的标题
chinese_title: 一个看似很厉害的标题
english_title: One NewBee name
class: 网络空间人工智能9102班
english_abstract: This is a test abstract. We'll going to test it.
chinese_abstract: |
  总之这里是测试用的综述，在这里填写你的综述就可以了，并且改掉下面关键词的内容。
  如果你需要换行，那么请换行两次，并且保留前面的空格。
  就像这样。
english_key_words: this  is  english  key  words  separated  by  two  space
chinese_key_words: 这里　是　中文　关键词　用　全角　空格　分隔 
---


# 第1章　测试（这里的空格按要求要用中文空格，按shift+space切换全角符号后按空格就有，这里已经是全角了）

## 1.1　测试概况(这里章节号和标题间也要有中文空格)

正文中文为小四号宋体，英文为小四号Times New Roman，各段行首缩进两个汉字。参考文献标注用中括号，以上标的形式标注。也就是^这个样子^，如果你需要下标，那么可以~这个样子~。

![如果你要图题和图序，在这里填写，格式调整好了，后面那里是图片路径（本地/网络均可）](./test_image.jpg)

测试复杂例子：~~12*4*14jla***sdf***af**d**safd^123^adfjk~123~s3~~`dsafo2jef`^^123^^

### 1.1.1　测试三号标题

(1) 这里测试一下列表的效果
(2) 列表的效果是可以调整的，但是貌似没必要
(3) 这里测试一下列表的效果
(4) 这个拓展的这种格式就是宋老师要求的格式

或者无序列表：

- test
- 测试

如果有公式，一定要用

$$这样换行出来的公式，还会自动居中，然后自己在转换出来的的docx里处理公式标号的问题$$

$$write formula with mathjax, not bad$$

$$a \equiv b \mod n^2$$

接下来我复制几个来展示测试的效果，章节之间应该手动插入分页符，点到下一章标题的第一个字那里插入即可。

# 第2章　测试

## 2.1　测试概况

正文中文为小四号宋体，英文为小四号Times New Roman，各段行首缩进两个汉字。参考文献标注用中括号，以上标的形式标注。也就是^这个样子^，如果你需要下标，那么可以~这个样子~。

测试复杂例子：~~12*4*14jla***sdf***af**d**safd^123^adfjk~123~s3~~`dsafo2jef`

``` cpp
代码段测试
    2134124
发大水v从
#include<stdio.h>
int main() {
    printf("Hello, World!\n");
    return 0;
}
```



![](./test_image.jpg "如果你要图题和图序，在这里填写，格式调整好了")

![](C:\Users\Thinker-Z\source\repos\md2docx-resharp\TestFiles\yaml.jpg "这是windows本地图片")  

![](https://d1yjjnpx0p53s8.cloudfront.net/styles/logo-thumbnail/s3/0022/2657/brand.gif?itok=IMARP1Qw "这是网络图片")  

### 2.1.1　测试三号标题

(1) 这里测试一下列表的效果
(2) 列表的效果是可以调整的，但是貌似没必要
(3) 这里测试一下列表的效果

默认的应该是：

1. test
2. 测试

或者无序列表：

- test
- 测试

再来一个试试

- 123
- 456
- 789

再来一个试试

- 123
- 456
- 789

再来一个试试

- 123
- 456
- 789

再来一个试试

- 123
- 456
- 789

再来一个试试

- 123
- 456
- 789

再来一个试试

- 123
- 456
- 789

表格有好几种写法，比如：

| Right | Left | Default | Center |
|------:|:-----|---------|:------:|
|   12  |  12  |    12   |    12  |
|  123  |  123 |   123   |   123  |
|    1  |    1 |     1   |     1  |

-------------------------------------------------------------
Here is a footnote reference,[^1] and another.[^longnote]

This is another reference to [^1]

[^1]: Here is the footnote.

And another reference to [^longnote]

[^longnote]: Here's one with multiple blocks.

    Subsequent paragraphs are indented to show that they
belong to the previous footnote.

    > This is a block quote
    > Inside a footnote
    
        { some.code }
    
    The whole paragraph can be indented, or just the first
    line.  In this way, multi-paragraph footnotes work like
    multi-paragraph list items.

This paragraph won't be part of the note, because it
isn't indented.

# 结束语应该是和综述同一个格式的，生成以后拷贝过来使用，这里只是做个声明，生成之后删去

结束语的格式倒是和正文一样，不用调整。