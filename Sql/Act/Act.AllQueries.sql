-- ACT_DATA [Root]
select *
from act_data ad
where
    ad.id_act_data = @ID


-- RK_REL_ACT_PROTOCOL [List]
select *
from rk_rel_act_protocol ap
where 
    ap.id_act_data = @ID


-- ACT_PERFORMER [List]
select *
from act_performer ap
where
    ap.id_act_data = @ID


--ACT_SR_IZM [List]
select *
from act_sr_izm ai
where
    ai.id_act_data = @ID


-- ACT_WORK_TIME [List]
select *
from act_work_time aw
where
    aw.id_act_data = @ID


-- REL_RK_ACT_ZADACHA [List]
select *
from rel_rk_act_zadacha az
where
    az.id_act_data = @ID


-- RK_REL_ACT_STATUSES [List]
select *
from rk_rel_act_statuses st
where
    st.id_act_data = @ID


-- RK_ACT_ACTUAL_LINKS [1=1]
select *
from rk_act_actual_links al
where
    al.id_act_data = @ID


-- RK_REL_ACT_AUTHORS [List]
select *
from rk_rel_act_authors a
where
    a.id_act_data = @ID


-- RK_REL_ACT_ERROR_CLASS [List]
select *
from rk_rel_act_error_class ec
where
    ec.id_act_data = @ID


-- RK_REL_ACT_REQUEST_DETAILS [List]
select *
from rk_rel_act_request_details ad
where
    ad.id_act_data = @ID
