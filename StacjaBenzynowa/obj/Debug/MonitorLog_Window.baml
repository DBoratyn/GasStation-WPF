   M S B A M L   `   `   `  ����J  FStacjaBenzynowa, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:StacjaBenzynowaStacjaBenzynowa  5   	   '    !StacjaBenzynowa.MonitorLog_Window   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:StacjaBenzynowa     5   	     � Title$  Dane zbiornikow��5   	   $	��450��6!   $	��800��6.   .��5	      � 
�������.+�5   
   �� -   5         ��Name$ LogListView��5   (   $y�Visible=�6   $��10,10,10,51q�5      $��Disabled=�5      $��1��6I   
���   �
���   ���5   )   Z� ��5      �� 5      .R�5      ��  �� Orientation$ Vertical=�6!   $��Disabled=�68   .+�5      �� $��20(�68   
���  ��$��WrapWithOverflow=�6W   $��Copperplate Gothic Bold)�6w   ��6$   �� *Id+6w   �� 5      $��15(�6Y   $��Italic$�6g   $
��Wrap=�6z   $��Copperplate Gothic Bold)�6�   ��6$   ��  �� Path$
 Date� �� StringFormat$ 	Date: {0}��6�   �� 5      $��15(�6Y   $��Italic$�6g   $
��Wrap=�6z   $��Copperplate Gothic Bold)�6�   ��6$   �� $
 Time�$ 	Time: {0}��6�   �� 5      $��TEMPERATURE��6$   $��15(�67   $��Italic$�6E   $
��Wrap=�6X   $��Copperplate Gothic Bold)�6l   �� 5      $��15(�6g   $��Italic$�6u   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ BenzynaE95_T�$ BenzynaE95: {0}��6�   �� 5      $��15(�6g   $��Italic$�6u   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ BenzynaE98_T�$ BenzynaE98: {0}��6�   �� 5      $��15(�6k   $��Italic$�6y   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ OlejNapeowy_T�$ Olej Napedowy: {0}��6�   �� 5      $��15(�6Y   $��Italic$�6g   $
��Wrap=�6z   $��Copperplate Gothic Bold)�6�   ��6$   �� $ LPG_T�$ LPG: {0}��6�   �� 5      $��Pressure��6$   $��15(�64   $��Italic$�6B   $
��Wrap=�6U   $��Copperplate Gothic Bold)�6i   �� 5      $��15(�6g   $��Italic$�6u   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ BenzynaE95_P�$ BenzynaE95: {0}��6�   �� 5      $��15(�6g   $��Italic$�6u   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ BenzynaE98_P�$ BenzynaE98: {0}��6�   �� 5      $��15(�6k   $��Italic$�6y   $
��Wrap=�6�   $��Copperplate Gothic Bold)�6�   ��6$   �� $ OlejNapeowy_P�$ Olej Napedowy: {0}��6�   �� 5       $��15(�6Y   $��Italic$�6g   $
��Wrap=�6z   $��Copperplate Gothic Bold)�6�   ��6$   �� $ LPG_P�$ LPG: {0}��6�   5!      5"      5$      �� 5'   
   -   5         ��Name$ back_button��5'      $��Wróć��6'   $
��Left=�66   $��
10,389,0,0q�5(      $	��Top=�6!   $��60��69   
���   �$��Copperplate Gothic Bold)�5)       $��16(�6E   $
��Bold"�6S   ��5(   D   Z� ��6Z   Z� 5)   e   �� 5+   
   -   5         ��Name$ YearList��5+      $
��Left=�6q   $��659,387,0,0q�6�   $	��Top=�6�   $	��120��6�   
���������6S   �� *years+��5,      �� 5-       �� EndPoint$	 0,1&�6&    �� 
StartPoint$	 0,0&�65   .��5.      � 	 � Color$	 	#FFF0F0F0��6#   
 � Offset$
 0Q�65   � 5/      $	 White��6#   $
 1Q�61   50      52      �� 53   
   -   5        $ 	MonthList��53      $
��Left=�6t   $��472,387,0,0q�6�   $	��Top=�6�   $	��120��6�    J� RenderTransformOrigin$ 0.551,0.238&�6�   
���������6T   �� *Months+��54      �� 55      $	 0,1&�6&   $	 0,0&�65   .��56      � $	 	#FFF0F0F0��6#   $
 0Q�65   � 57      $	 White��6#   $
 1Q�61   58      5:      �� 5;   
   -   5         ��Name$ Wlasciciel_Copy18��5;      $��Miesiac:��6+   $
��Left=�6>   $��401,384,0,0q�5<      $	��Top=�6"   $��Copperplate Gothic Light)�6:   $
��Bold"�6`   $��14(�6r   
���   �$��66��5=       $��Italic$�6A   ��6+   Z� 6A   �� 5>   
   -   5        $ Wlasciciel_Copy17��5>      $
��Rok:��6+   $
��Left=�6:   $��605,384,0,0q�5?      $	��Top=�6"   $��Copperplate Gothic Light)�6:   $
��Bold"�6`   $��14(�6r   
���   �$��49��5@       $��Italic$�6A   $ 0.454,1.782&�6T   ��6+   Z� 6T   5A      5B      