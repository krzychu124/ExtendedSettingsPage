import { FC } from "react";
import { Widget } from "cs2/bindings";
import { getModule } from "cs2/modding";

const InputBinding: FC<Widget<any>> = getModule("game-ui/menu/widgets/input-binding-field/input-binding-field.tsx", "BoundInputBindingField");

export const ExtendedKeybinding = (data: Widget<{ icon?: string }>) => {
  const hasIcon = !!data.props.icon;
  return (
    <div style={{display:'flex', justifyContent: 'space-between'}}>
      {hasIcon && <div style={{display: 'flex', alignItems: 'center', justifyContent: 'center', width: '30rem', marginLeft: '10rem', marginRight:'5rem'}}>
        <img src={data.props.icon} width="25" height="25" />
      </div>}
      <div style={{flexGrow: '1'}}>
        <InputBinding {...data} />
      </div>
    </div>
  );
}