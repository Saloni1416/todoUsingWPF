   M S B A M L   `   `   `  ����G  CactualUiTodo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:letsTodoletsTodo  5          letsTodo.MainWindow   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:letsTodo     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        � Title$  
MainWindow��5      $	��500��5	      $	��300��5
      .��5      �� 
���   �$��1q�6!   ._�5   
   �� .+�5      �� $	��486��5      $��27��5      $��Center=�5       �� Orientation$ 
Horizontal=�5      .+�5      �� $��61��6   $��12(�6#   .��61   
My Tasks5      �� 5      -   5         ��Name$ 	AddButton��5      
�������
������� � Cursor$
 Hand��5      $��24��6#   $��26��6/   .��5       �� $��26��5!      $��12��5"      $��
plusva.png��5#      5$      �� 5%      -   5        $��26��5&      
�������
�������.��5*      �� $��18��5+      $��12��5,      $��/checked.png��5-      5.      50      � 55      $	��777��6    � ColumnDefinitions 56      �� 57      $
��198* �6'   �� 58      $
��167* �6'   �� 59      $
��412* �6'   .+�5=      �� -   5         ��Name$ ListBox��5>      $��3��5?      $	��415��5@      $	��100��5A      $
��Left=�5B      $��0q�5C      $��15(�5D       �� SelectionMode$ Multiple=�5F      5G      � 5M      $	��569��6   .+�5O      �� $	��499��5P      $
��Left=�5Q      $��11(�5R      .��6#   Completed Tasks5T      �� 5U      -   5        $ RemoveButton��5V      $��20��5W      $��
93,2,452,3q�5X      
�������
�������$
 Hand��5\      .��5`      �� $��22��5a      $��15��5b       J� RenderTransformOrigin$ 2.203,0.579&�5c      $��./cleaner.png��5d      5e      5f      �� 5h      -   5        $ ListBoxCompleted��5i      $	��490��5j      $	��100��5k      $��0q�5l      $��15(�5m      $
��Left=�5n      5r      5s      5t      