   M S B A M L   `   `   `  ����L  HQuiz Configurator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:Quiz_Configurator.WindowsQuiz_Configurator.Windows  5   	   '    !Quiz_Configurator.Windows.NewPack   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:Quiz_Configurator.Windows     5   	     � Title$  New Question Pack��5   	   $	��240��6#   $	��200��60    � 
ResizeMode$ NoResize=�6<    � WindowStyle$ 
ToolWindow=�6R   .��5	      � .+�5   
   �� $��
10 0 10 10q�6   $��3��6)   .+�5      �� $��
Pack Name:��6   $
��Bold"�6)   �� 5      .��6   
<PackName>5      �� 5      $��Difficulty:��6   $
��Bold"�6*   �� 5      .@�5      �� $
��Easy��6   �� 5      $��Medium��6    �� 
IsSelected$
 True��60   �� 5      $
��Hard��6   5      ]� 5      .+�5      �� $��Time Limit:��6   $
��Bold"�6.   �� 5      $�� ��6    �� ContentStringFormat$ #{0} seconds}��5      �� 5      $  {0} seconds��5      $��Right=�5      ��5      ��  �� ElementName$ slider�� �� Path$ Value�5      5      �� 5      -   5         ��Name$ slider��5       � Minimum$ 5Q�5       	 � Maximum$		 120Q�5!      
 �� TickFrequency$
 5Q�5"       �� TickPlacement$ BottomRight=�5#       �� IsSnapToTickEnabled$
 True��5$       � Value$ 30Q�5%      ]� 5'      $��Bottom=�6   .+�5(      �� $��Cancel��6   $��20��6*   $��50��66   $��
20 20 0 20q�6A   �� 5)      $��Create��6   $��20��6+   $��50��67   5+      5-      5.      5/      