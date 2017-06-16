//
//  EventDetailViewController.h
//  ItagConference2017_360
//
//  Created by Joe Baldwin on 6/12/17.
//  Copyright © 2017 jbaldwin@hbs.net. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface EventDetailViewController : UIViewController
@property (weak, nonatomic) IBOutlet UILabel *NameLabel;
@property (weak, nonatomic) IBOutlet UILabel *TimeLabel;
@property (weak, nonatomic) IBOutlet UILabel *PresenterLabel;
@property (weak, nonatomic) IBOutlet UILabel *SummaryLabel;

@property (weak, nonatomic) IBOutlet UIImageView *RadioImage;
@property (weak, nonatomic) IBOutlet UILabel *ProximityLabel;

-(void) UpdateDisplayValues;

@end
