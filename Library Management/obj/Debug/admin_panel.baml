   M S B A M L   `   `   `  ����M  ILibrary Management, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Library_ManagementLibrary_Management  5   	   $    Library_Management.admin_panel   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Library_Management     5   	   -   5          �Name$  Admin_Panel��5   	    � Title$ Admin Panel��5   	   $��563.5��6   $	��512��6,    � Icon$ images/logo.png��68    � WindowStartupLocation$ CenterScreen=�6O   ��5	      �� 5
   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��125* �6   �� 5      $
��379* �6   ��5   
   �� 5       �� ImageSource$ images/adminpanel.JPG��6   .+�5   
   o� -   5         o�Name$ 
admin_menu��5      $��29��6#   $	��Top=�6/   $��Stencil)�6G   $��2��6\   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5      � 	 � Color$	 	#FF977777��6#   
 � Offset$
 0Q�65   � 5      $	 	#FFB7DBF3��6#   $
 1Q�65   5      .@�5      m� $��Student��6   $��29��6?   ��6(   Z� .@�5      m� -   5        $��All Student��5      60   �� 5      m� 5      -   5        $��Search Student��5      63   �� 5      m� 5       -   5        $��Add Student��5       60   �� 5!      m� 5"      -   5        $��Student Requestest��5"      5#      5$      �� 5%      ���	#FF060303$��0q�60   ���	#FF0F07076D   m� 5&      $��Books��6.   ��6   Z� .@�5'      m� -   5        $��View all��5'      6-   �� 5(      m� 5)      -   5        $��Add Book��5)      6-   �� 5*      m� 5+      -	   5        $��	Lend Book��5+      6.   �� 5,      m� 5-      -
   5        $��
Books Away��5-      6/   5.      �� 5/      m� 50      -   5        $
��Help��50      6%   �� 51      m� 52      -   5        $��About Us��52      6)   �� 53      m� 54      -   5        $��Logout��54      ��6<   Z� 55       � 56   
   -   5          �Name$ frame��56      $�� ��6   $
��Left=�6*   $	��499��6E   $��0,29,0,0q�6R   $	��Top=�6d   $	��502��6|   $��2��6�     � NavigationUIVisibility$ Hidden=�6�   57      58      