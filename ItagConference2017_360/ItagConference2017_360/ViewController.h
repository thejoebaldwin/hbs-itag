//
// Please report any problems with this app template to contact@estimote.com
//

#import <UIKit/UIKit.h>
#import "BeaconNotificationsManager.h"

@interface ViewController : UIViewController <UITableViewDataSource, UITableViewDelegate>
{
    
}
- (IBAction)DoneButtonClick:(id)sender;
@property (weak, nonatomic) IBOutlet UITableView *RegistrationTableView;
@property (nonatomic) BeaconNotificationsManager *beaconNotificationsManager;
@property (nonatomic) ESTBeaconManager *beaconManager;



@property (weak, nonatomic) IBOutlet UITableView *EventTableView;

@property (weak, nonatomic) IBOutlet UISwitch *NotifySwitch;
- (IBAction)NotifySwitchChanged:(id)sender;


@end
